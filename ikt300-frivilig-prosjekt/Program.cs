namespace ikt300_frivilig_prosjekt
{

    public class Program
    {
       
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            Form1 formCool = new Form1();
            Application.Run(formCool);
            Program p = new Program();
            p.programStart(formCool);
        }

        public void programStart(Form1 form)
        {
            form.displayVolt();
        }
    }
}