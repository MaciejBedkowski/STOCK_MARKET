using System;
using System.Collections.Generic;

namespace Stock
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stockIsOn = true;
            bool onTransaction = false;
            int option = 10;
            int optionTransaction = 10;
            int lowerLimit = 0;
            int topLimit = 0;
            int value = 0;
            List<StockItem> listOfferts = new List<StockItem>();
            List<string> listOfInstruments = new List<string>();
            string pathInstruments = "instruments.txt";
            string pathTransaction = "transaction.xml";
            string decysion;
            string decysionTransaction;
            string lowerLimitTime;
            string topLimitTime;
            string instrument;
            string valueToCheck;
            Instruments checkInstruments = new Instruments();

            //Initial STOCK!
            var stockOffer = new StockOffer();
            stockOffer.StockOfferGenerate(listOfferts, pathInstruments);
            

            Console.WriteLine("WELCOME TO STOCK MARKET!");
            while (stockIsOn)
            {

                Console.WriteLine("Press 0 - to exit");
                Console.WriteLine("Press 1 - to get offert history");
                Console.WriteLine("Press 2 - to set wather");
                Console.WriteLine("Press 3 - to get transactions");

                decysion = Console.ReadLine();

                try
                {
                    option = Int32.Parse(decysion);
                }
                catch
                {
                    Console.WriteLine("Incorrect data");
                }

                switch (option)
                {
                    case 0:
                        stockIsOn = false;
                        break;
                    case 1:
                        Console.WriteLine("Specify the time period");
                        Console.WriteLine("The lower limit");
                        lowerLimitTime = Console.ReadLine();

                        try
                        {
                            lowerLimit = Int32.Parse(lowerLimitTime);
                        }
                        catch
                        {
                            Console.WriteLine("Incorrect data");
                        }

                        Console.WriteLine("The top limit");
                        topLimitTime = Console.ReadLine();

                        try
                        {
                            topLimit = Int32.Parse(topLimitTime);
                        }
                        catch
                        {
                            Console.WriteLine("Incorrect data");
                        }

                        for (int i = topLimit-1; i >= lowerLimit-1; i--)
                        {
                            Console.WriteLine(listOfferts[i].date +"  "+ listOfferts[i].instrument+"  "+ listOfferts[i].value);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the parameters to buy offers");
                        Console.WriteLine("What instrument:");

                        
                        checkInstruments.CreateListOfInstruments(pathInstruments);
                        checkInstruments.SchowInstruments();

                        instrument = Console.ReadLine();
                        instrument = instrument.ToUpper();

                        if (!checkInstruments.IfInstrumentExist(instrument))
                        {
                            Console.WriteLine("The selected instrument is not in the list!");
                            continue;
                        }

                        Console.WriteLine("Up to what amount to buy:");
                        valueToCheck = Console.ReadLine();

                        try
                        {
                            value = Int32.Parse(valueToCheck);
                        }
                        catch
                        {
                            Console.WriteLine("Incorrect data");
                        }

                        SetWather setWather = new SetWather(instrument,value);
                        setWather.BuyOffert(listOfferts, pathTransaction);
                        
                        break;
                    case 3:
                        onTransaction = true;
                        while(onTransaction)
                        {
                            Console.Clear();
                            Console.WriteLine("Press 0 - to exit transactions");
                            Console.WriteLine("Press 1 - to get all transaction");
                            Console.WriteLine("Press 2 - to get chosen transaction");

                            decysionTransaction = Console.ReadLine();
                            try
                            {
                                optionTransaction = Int32.Parse(decysionTransaction);
                            }
                            catch
                            {
                                Console.WriteLine("Incorrect data");
                            }
                            GetTransactions getTransactions = new GetTransactions();
                            getTransactions.LoadTransactions(pathTransaction);

                            switch (optionTransaction)
                            {

                                case 0:
                                    onTransaction = false;
                                    break;
                                case 1:
                                    getTransactions.ShowAllTransaction();
                                    break;
                                case 2:
                                    
                                    checkInstruments.CreateListOfInstruments(pathInstruments);
                                    checkInstruments.SchowInstruments();

                                    Console.WriteLine("Enter the instrument you want to filter by");

                                    instrument = Console.ReadLine();
                                    instrument = instrument.ToUpper();

                                    if (!checkInstruments.IfInstrumentExist(instrument))
                                    {
                                        Console.WriteLine("The selected instrument is not in the list!");
                                        continue;
                                    }

                                    getTransactions.ShowSpecyficTransaction(instrument);
                                    break;
                                default:
                                    Console.WriteLine("an invalid option was entered");
                                    break;
                            }

                            Console.WriteLine("Press to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        
                        break;
                    default:
                        Console.WriteLine("an invalid option was entered");
                        break;
                }

                Console.WriteLine("Press to continue");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
