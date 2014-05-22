using System;
using System.Windows.Forms;

public class C {

    public static ObsRes MboxHandler(ObsArg value) {
        MessageBox.Show("Item = " + value.arg);
        return new ObsRes(value.arg, "MBox");
    }

}