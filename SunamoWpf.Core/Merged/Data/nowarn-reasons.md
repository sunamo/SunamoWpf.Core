# NoWarn — důvody

## CA1416 — platformově specifické API na Windows-only assembly
**Zdroj:** `TargetFramework` je `net10.0-windows7.0`, celá assembly je jen pro Windows, přesto analyzer hlásí CA1416 (např. `System.Drawing.Image.FromFile` v `ImageWithPath`).
**Proč nelze opravit bez rizika:** `[SupportedOSPlatform("windows")]` na sdílených třídách se kaskádovitě propaguje na všechny volající projekty a počet warningů násobně roste místo klesá.
**Kdy přehodnotit:** pokud .NET SDK v budoucnu začne CA1416 automaticky potlačovat na základě Windows-specific TFM.

## CS8625, CS8618, CS8603, CS8601 — nullable reference warningy
**Zdroj:** starý WPF kód (extrahovaný z monolitu `SunamoWpf`) s `Nullable=enable` zapnutým dodatečně, desítky call sites (např. `ControlInitData`).
**Proč nelze opravit plošně:** vyžaduje individuální ověření nullability u desítek míst bez možnosti reálného otestování chování.
**Kdy přehodnotit:** při postupné revizi nullability jednotlivých datových tříd.
