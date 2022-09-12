# CustomJsonEnumSerializer
A custom JSON serializer for Enums.

## Context
There is a **ReportRequest** which is sent and received via REST requests.  

This class has a **_Category_ Category** property, which is an enum:
```
    public class ReportRequest
    {
        public DateTime? Date { get; set; }
        public Category Category { get; set; }
        public int? ConstructionYear { get; set; }
        public string? Discriminator { get; set; } // can be nation, culture, language...
    }
```
...and here is the **Category** enum:
```
    public enum Category
    {
        Eigentumswohnung,
        Condominium,
        Einfamilenhaus,
        SingleFamilyHouse,
        ...
    }
```
This enum contains 'duplicates'. For example, _Eigentumswohnung_ and _Condominium_ have the same meaning. The same for _Einfamilenhaus_ and _SingleFamilyHouse_ and so on.

We call _Eigentumswohnung_ and _Condominium_ **terms** of the same **notion**, which is _Condominium_.
Similarly, _SingleFamilyHouse_ is a **notion** which can be represented by two different terms: _Einfamilenhaus_ and _SingleFamilyHouse_.

### The challenge
What we want is to "unify" these **terms** and use internally only one, which is the **notion**.  

For instance, even if we receive _Eigentumswohnung_ (which is a valid value!) we want to have it as _Condominium_ after the incoming JSON is deserialized. Also, if the incoming JSON has Category = _Condominium_, we want to deserialize it as _Condominium_.

Additionally, we also want to be able to "translate" back the internal notion _Condominium_ into the original value based on the **Discriminator** property.  

Have a look at the following tables:
### Incomming
| Original value      | ...will be "translated" to |
|---------------------|----------------------------|
| Eigentumswohnung    | Condominium                |
| Condominium         | Condominium                |
| Einfamilenhaus      | SingleFamilyHouse          |
| SingleFamilyHouse   | SingleFamilyHouse          |
| Mehrfamilienhaus    | MultiFamilyDwelling        |
| MultiFamilyDwelling | MultiFamilyDwelling        |
| Grundstueck         | UndevelopedPlot            |
| UndevelopedPlot     | UndevelopedPlot            |

> As you can see, the terms _Eigentumswohnung_, _Condominium_ represents the same notion, which is _Condominium_. The same is valid for the others. 

### Output
| Value       | Discriminator | ...will be "translated" to |
|-------------|---------------|----------------------------|
| Condominium | DE            | Eigentumswohnung           |
| Condominium | AT            | Eigentumswohnung           |
| Condominium | HR            | Condominium                |
| ...         |               |                            |
| ...         |               |                            |

To translate back from a more generic item (a notion) to a more specific one (a term) we need an extra piece of information, which is kept in **Discriminator** property.  

Without this piece of information it would be impossible to translate, for example, _Condominium_ into the more specific _Eigentumswohnung_ (for **Discriminator** = _**AT**_).  
The map above is kept into **CategoryTranslationMap**.

## Solution
A custom JSON Serializer for **ReportRequest** is implemented in **ReportRequestConverter**. This uses the map defined in **CategoryTranslationMap** which, in turn uses **TranslationItem** just to store the data.

> NOTE: please have a look at the comments in **ReportController** as well.