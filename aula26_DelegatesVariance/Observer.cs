public class ObsRes
{
    public int res;
    public string msg;

    public ObsRes(int r, string m) {
        res = r;
        msg = m;
    }
}

public class ObsArg
{
    public int arg;

    public ObsArg(int v)
    {
        arg = v;
    }
}

public delegate ObsRes Observer(ObsArg value);


