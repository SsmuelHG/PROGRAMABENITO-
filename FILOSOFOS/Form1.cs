namespace FILOSOFOS
{
    public partial class Form1 : Form
    {
        public bool cubierto1 = true, cubierto2 = true, cubierto3 = true, cubierto4 = true, cubierto5 = true;
        public Semaphore sema = new Semaphore(2, 3);//Semaphore 2, 3 sirve para indicar que dos estarn en proceso mientars 3 no, indicando que 2 comeran al mismo tiempomientras los otros 3 no
        public Form1()

        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SIRVE PARA INICIAR LOS HILOS PARA PODER REPETIR 5 VECES EL PROCESO 

            for (int i =1 ; i <= 5; i++)
            {
            Thread bart1 = new Thread(filobart1);
            Thread bart2 = new Thread(filobart2);
            Thread bart3 = new Thread(filobart3);
            Thread bart4 = new Thread(filobart4);
            Thread bart5 = new Thread(filobart5);
                bart1.Start();
                bart2.Start();
                bart3.Start();
                bart4.Start();
                bart5.Start();

            }
        }
        //SE DECLARA LA ACCION EN CADA FILOSOFO
        public void filobart1()
        {
            //EL SEMA ES PARA INDICAR LA ACCION DE CADA FILOSOFO 
            sema.WaitOne();
                if (cubierto1 == true && cubierto2 == true)
            {
                //SE INDICA CUALES CUBIERTOS ESTAN UTILIZANDO 
                cubierto1 = false;
                cubierto2 = false;
                Invoke((Delegate)new Action(() =>
                {
                    bart1.Visible = false;
                    comelon1.Visible = true;
                    cubi1.Visible = false;
                    cubi2.Visible = false;
                }));
                Thread.Sleep(3500);
            }
            Invoke((Delegate)new Action(() => //EL INVOKE SIRVE PARA HACER UN SUB-PROCESO 
            {
                bart1.Visible = true;//ES PARA LLAMAR EL FILOSOFO 
                comelon1.Visible = false;//PARA LLAMAR AL COMELON 
                cubi1.Visible = true;//PARA LLAMAR LOS CUBIERTOS A UTILIZAR 
                cubi2.Visible = true;//PARA LLAMAR LOS CUBIERTOS A UTILIZAR 
            }));
            //Son los cubiertos con lo que comeran los filobart큦
            cubierto2 = true;//HACEN REFERENCIA DE CUALES CUBIERTOS ESTAN 
            cubierto3 = true;
            sema.Release(); //Con esto reinicia el semanfora 
        }
        public void filobart2()
        {

            sema.WaitOne();
            if (cubierto2 == true && cubierto3 == true)
            {
                cubierto1 = false;
                cubierto2 = false;
                Invoke((Delegate)new Action(() =>
                {
                    bart2.Visible = false;
                    comelon2.Visible = true;
                    cubi2.Visible = false;
                    cubi3.Visible = false;
                }));
                Thread.Sleep(3500);
            }
            Invoke((Delegate)new Action(() =>
            {
                bart2.Visible = true;
                comelon2.Visible = false;
                cubi2.Visible = true;
                cubi3.Visible = true;
            }));
            //Son los cubiertos con lo que comeran los filobart큦
            cubierto3 = true;
            cubierto4 = true;
            sema.Release(); //Con esto reinicia el semanfora 

        }
        public void filobart3()
        {
            sema.WaitOne();
            if (cubierto3 == true && cubierto4 == true)
            {
                cubierto3 = false;
                cubierto4 = false;
                Invoke((Delegate)new Action(() =>
                {
                    bart3.Visible = false;
                    comelon3.Visible = true;
                    cubi3.Visible = false;
                    cubi4.Visible = false;
                }));
                Thread.Sleep(3500);
            }
            Invoke((Delegate)new Action(() =>
            {
                bart3.Visible = true;
                comelon3.Visible = false;
                cubi3.Visible = true;
                cubi4.Visible = true;
            }));
            //Son los cubiertos con lo que comeran los filobart큦
            cubierto3 = true;
            cubierto4 = true;
            sema.Release(); //Con esto reinicia el semanfora 

        }
        public void filobart4()
        {
            sema.WaitOne();
            if (cubierto3 == true && cubierto4 == true)
            {
                cubierto3 = false;
                cubierto4 = false;
                Invoke((Delegate)new Action(() =>
                {
                    bart4.Visible = false;
                    comelon4.Visible = true;
                    cubi4.Visible = false;
                    cubi5.Visible = false;
                }));
                Thread.Sleep(3500);
            }
            Invoke((Delegate)new Action(() =>
            {
                bart4.Visible = true;
                comelon4.Visible = false;
                cubi4.Visible = true;
                cubi5.Visible = true;
            }));
            //Son los cubiertos con lo que comeran los filobart큦
            cubierto4 = true;
            cubierto5 = true;
            sema.Release(); //Con esto reinicia el semanfora 



        }
        public void filobart5()
        {
            sema.WaitOne();
            if (cubierto5 == true && cubierto1 == true)
            {
                cubierto5 = false;
                cubierto1 = false;
                Invoke((Delegate)new Action(() =>
                {
                    bart5.Visible = false;
                    comelon5.Visible = true;
                    cubi5.Visible = false;
                    cubi1.Visible = false;
                }));
                Thread.Sleep(3500);
            }
            Invoke((Delegate)new Action(() =>
            {
                bart5.Visible = true;
                comelon5.Visible = false;
                cubi5.Visible = true;
                cubi1.Visible = true;
            }));
            //Son los cubiertos con lo que comeran los filobart큦
            cubierto5 = true;
            cubierto1 = true;
            sema.Release(); //Con esto reinicia el semanfora 




        }

    }
}