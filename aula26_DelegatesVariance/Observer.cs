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

public class ObsResExtended : ObsRes {
	public ObsResExtended(int r, string m) : base(r, m)
	{
	}
}

public delegate ObsRes Observer(ObsArg value);


