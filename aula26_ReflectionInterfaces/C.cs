using System;
using System.Windows.Forms;

public class C : Observer
{

    public void Invoke(int value)
    {
        MessageBox.Show("Item = " + value);
    }

}