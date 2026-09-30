---
schema_version: 2
type: library
file_count: 493
delete_recommendation_percent: 10
generated_date: 2026-09-30
generated_time: 15:08:08
---

## Description

Samostatný (self-contained) balíček se základními WPF typy: datové struktury, logging, helpery, ovládací prvky, storage a okna. Zdroje dřívějších balíčků SunamoWpf.Data, Logging, Helpers, Controls, Storage a Windows jsou sloučeny sem do `SunamoWpf.Core\Merged\<Balicek>`.
Kód dříve referencovaných balíčků SunamoUtils, Converters, Extensions a AwesomeFont je zkopírován do `Internal\` a používá se jako internal, takže balíček nereferencuje žádné jiné Sunamo balíčky. Ostatní WPF balíčky (Data, Logging, Helpers, Controls, Storage, Windows) jsou dnes jen prázdné zástupné balíčky.
