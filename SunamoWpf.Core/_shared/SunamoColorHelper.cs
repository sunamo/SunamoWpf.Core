// KnownColor bude taky něco z Drawing
//public class SunamoColorHelper
//{
//    public static SunamoColor Parse(string s)
//    {
//        s = s.TrimStart(AllChars.num);

//        var cn = EnumHelper.Parse<KnownColor>(s, KnownColor.Control);

//        if (cn != KnownColor.Control)
//        {
//            return Color.FromKnownColor(cn).ToSunamoColor();
//        }
//        else if (HexHelper.IsInHexFormat(s))
//        {
//            var c = StringHexColorConverter.ConvertFrom(s);

//            if (c.HasValue)
//            {
//                //SunamoColor;
//                System.Drawing.Color c2 = c.Value;
//                return c2.ToSunamoColor();
//            }
//            else
//            {
//                c = StringHexColorConverter.ConvertFrom2(s);
//                if (c.HasValue)
//                {
//                    return c.Value.ToSunamoColor();
//                }
//                else
//                {
//                    return null;
//                }
//            }

//        }
//        return null;
//    }
//}
