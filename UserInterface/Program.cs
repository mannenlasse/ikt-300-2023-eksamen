using PsuController;
using PsuManager;

namespace UserInterface;

public class Program
{
    private static void Main(string[] args)
    {/*
        ApplicationConfiguration.Initialize();
        var formCool = new Form1();
        Application.Run(formCool);
        var p = new Program();
        p.ProgramStart(formCool); */
        
        //ApplicationConfiguration.Initialize();
        var p = new Program();
        var psuManager = new PsuManager.PsuManager();
        psuManager.StartRuntimeComportCheck(60000, 1000);
    }

    private void ProgramStart(Form1 form)
    {
        
    }
}
