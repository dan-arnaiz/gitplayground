
public abstract class HypotheticalAbstract1
{
    protected int a;
    protected int b;

    public HypotheticalAbstract1(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public abstract int GetValue1();
    public abstract int GetValue2();
}

public abstract class HypotheticalAbstract2 : HypotheticalAbstract1
{
    public HypotheticalAbstract2(int a, int b) : base(a, b) { }

    public override int GetValue1()
    {
        return a + b;
    }
}

public abstract class HypotheticalAbstract3 : HypotheticalAbstract2
{
    public HypotheticalAbstract3(int a, int b) : base(a, b) { }

    public override int GetValue2()
    {
        return a * b;
    }
}

public class HypotheticalNonAbstract : HypotheticalAbstract3
{
    public HypotheticalNonAbstract(int a, int b) : base(a, b) { }
}