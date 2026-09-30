namespace SunamoWpf.Data;

public class SunamoPoint
{
    public SunamoPoint()
    {
    }

    public SunamoPoint(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; set; }
    public double Y { get; set; }

    public void Parse(string input)
    {
        var d = input.Split(',');
        //ParserTwoValues.ParseDouble(",", SHParts.RemoveAfterFirstFunc(input, char.IsLetter, new char[] { ',' }));
        X = double.Parse(d[0]);

        Y = double.Parse(d[1]);
    }

    public override string ToString()
    {
        //return ParserTwoValues.ToString(",", X.ToString(), Y.ToString());
        return X + "," + Y;
    }

    public object ToSystemWindows()
    {
        throw new NotImplementedException();
    }
}