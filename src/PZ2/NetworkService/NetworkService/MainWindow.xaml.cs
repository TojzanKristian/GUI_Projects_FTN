using NetworkService.Model;
using NetworkService.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;

namespace NetworkService
{
    public partial class MainWindow : Window
    {
        private static ObservableCollection<T2_PotrosnjaStruje> ListObj { get; set; }
        private int id;
        private double value;
        private bool file = false;
        private readonly Uri path = new Uri("LogFile.txt", UriKind.Relative);

        public MainWindow()
        {
            InitializeComponent();
            ListObj = new ObservableCollection<T2_PotrosnjaStruje>();
            CreateListener(); //Povezivanje sa serverskom aplikacijom
        }

        private void CreateListener()
        {
            var tcp = new TcpListener(IPAddress.Any, 25565);
            tcp.Start();

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = tcp.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(param =>
                    {
                        //Prijem poruke
                        NetworkStream stream = tcpClient.GetStream();
                        string incomming;
                        byte[] bytes = new byte[1024];
                        int i = stream.Read(bytes, 0, bytes.Length);
                        //Primljena poruka je sacuvana u incomming stringu
                        incomming = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        //Ukoliko je primljena poruka pitanje koliko objekata ima u sistemu -> odgovor
                        if (incomming.Equals("Need object count"))
                        {
                            //Response
                            /* Umesto sto se ovde salje count.ToString(), potrebno je poslati 
                             * duzinu liste koja sadrzi sve objekte pod monitoringom, odnosno
                             * njihov ukupan broj (NE BROJATI OD NULE, VEC POSLATI UKUPAN BROJ)
                             * */
                            Byte[] data = System.Text.Encoding.ASCII.GetBytes(PotrosnjaViewModel.Potrosnje.Count().ToString());
                            stream.Write(data, 0, data.Length);
                            file = false;
                        }
                        else
                        {
                            //U suprotnom, server je poslao promenu stanja nekog objekta u sistemu
                            Console.WriteLine(incomming); //Na primer: "Objekat_1:272"
                            string[] split = incomming.Split('_', ':');
                            int index = Int32.Parse(split[1]);
                            if (PotrosnjaViewModel.Potrosnje.Count > 0)
                                id = PotrosnjaViewModel.Potrosnje[index].Id;

                            value = double.Parse(split[2]);
                            T2_PotrosnjaStruje v = new T2_PotrosnjaStruje(id);
                            if (id != -1)
                            {
                                PotrosnjaViewModel.Potrosnje[index].Vrednost = value;
                                DragandDropViewModel.UpdateList(PotrosnjaViewModel.Potrosnje[index]);
                                UpisUFajl();
                            }
                            //################ IMPLEMENTACIJA ####################
                            // Obraditi poruku kako bi se dobile informacije o izmeni
                            // Azuriranje potrebnih stvari u aplikaciji
                            //UpisUFajl();
                        }
                    }, null);
                }
            });

            listeningThread.IsBackground = true;
            listeningThread.Start();
        }

        // Funkcija koja upisuje podatke u 'LogFile.txt'
        private void UpisUFajl()
        {
            if (!file)
            {
                StreamWriter wr;
                using (wr = new StreamWriter(path.ToString()))
                {
                    wr.WriteLine("Date Time:\t" + DateTime.Now.ToString() + "\tObject_" + id + "\tValue:\t" + value);
                }
            }
            else
            {
                StreamWriter wr;
                using (wr = new StreamWriter(path.ToString(), true))
                {
                    wr.WriteLine("Date Time:\t" + DateTime.Now.ToString() + "\tObject_" + id + "\tValue:\t" + value);
                }
            }
            file = true;
        }
    }
}