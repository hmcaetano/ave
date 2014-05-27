using System;

public class B {

    public static ObsRes ConsoleHandler(ObsArg value) {
        Console.WriteLine("ConsoleHandler = " + value.arg);
        return new ObsRes(value.arg, "Console");
    }
	
	public static ObsResExtended CovariantConsoleHandler(ObsArg value) {
        Console.WriteLine("CovariantConsoleHandler = " + value.arg);
        return new ObsResExtended(value.arg, "Covariant");
    }

}