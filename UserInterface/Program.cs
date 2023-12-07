using PsuController;
using PsuManager;

namespace UserInterface;

public class Program
{
    [STAThread]
    private static void Main(string[] args)
    {/*
        ApplicationConfiguration.Initialize();
        var formCool = new Form1();
        Application.Run(formCool);
        var p = new Program();
        p.ProgramStart(formCool); */
        
        ApplicationConfiguration.Initialize();
        var p = new Program();
        var test = new PsuManager.PsuManager();
    }

    private void ProgramStart(Form1 form)
    {
        
    }
}
