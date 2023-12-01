using PsuManager;

namespace UserInterface;

public class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        var formCool = new Form1();
        Application.Run(formCool);
        var p = new Program();
        p.ProgramStart(formCool);
    }

    private void ProgramStart(Form1 form)
    {
        
    }
}
