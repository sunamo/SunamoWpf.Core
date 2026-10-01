# NoWarn — důvody

## CS0649 — pole nikdy nepřiřazeno
**Zdroj:** `SunamoPasswordBox.pwbc`, `.btnc`, `.tbc` jsou seznamy prvků čtené v `Init()` (volání `ResourceDictionaryStyles.Margin10(...)`), ale nikde v kódu naplněny.
**Proč nelze opravit bez rizika:** oprava vyžaduje doplnit chybějící inicializační logiku (jaké konkrétní prvky do seznamů patří), což by mohlo změnit chování veřejného WPF controlu bez možnosti reálného otestování v appce, která ho používá.
**Kdy přehodnotit:** při reálném ladění vzhledu `SunamoPasswordBox` v konkrétní appce, kde půjde ověřit správné chování.

## CA1416 — platformově specifické API na Windows-only assembly
**Zdroj:** `TargetFramework` je `net10.0-windows7.0`, takže celá assembly je nativně jen pro Windows, ale analyzer přesto hlásí CA1416 na desítkách call sites napříč knihovnou (WinForms GDI+, registry, EventLog, WMI, AvalonEdit).
**Proč nelze opravit bez rizika:** označení `[SupportedOSPlatform("windows")]` na sdílených helper třídách (např. `TextBoxHelper`) se kaskádovitě propaguje na všechny volající místa v celé knihovně a warning počet násobně roste místo klesá; opravit případ po případu by znamenalo označit desítky tříd napříč celým projektem beze změny reálného chování.
**Kdy přehodnotit:** pokud .NET SDK v budoucnu začne CA1416 automaticky potlačovat na základě Windows-specific TFM (dle dokumentace by měl, v této verzi SDK se tak neděje).

## CS8600, CS8602, CS8625, CS8604, CS8618, CS8622, CS8603, CS8601, CS8629, CS8612 — nullable reference warningy
**Zdroj:** starý WPF kód (extrahovaný z monolitu `SunamoWpf`) s `Nullable=enable` zapnutým dodatečně, stovky call sites napříč celou knihovnou.
**Proč nelze opravit plošně:** vyžaduje individuální ověření nullability u stovek míst bez možnosti reálného otestování chování každého WPF controlu.
**Kdy přehodnotit:** při postupné revizi nullability jednotlivých controlů.

## CS8714, CS0108, CS0618, CS8073 — generické/legacy warningy
**Zdroj:** starý WPF kód, ojedinělé výskyty napříč knihovnou.
**Proč nelze opravit bez rizika:** stejné jako u nullable warningů výše — bez reálného otestování chování konkrétního controlu.
**Kdy přehodnotit:** při postupné revizi jednotlivých controlů.
