//namespace web.Collections;

//public class SunamoDictionaryWithKeysDependencyObject<T, U> : SunamoDictionary<T, U> where T : DependencyObject
//{
//    public List<U> GetValuesByValuesOfKeysProperty<X>(DependencyProperty dp, X co)
//    {
//        var vr = this.Where(d => EqualityComparer<X>.Default.Equals((X)d.Key.GetValue(dp), co));
//        return vr.Select(d => d.Value).ToList();
//        //return vr.SelectMany(d => d.Value);
//    }

//}

