using System.Drawing;
using System.Runtime.ExceptionServices;

namespace SmartHomeController 
{
    public class SmartHomeController
    {
        //private fields
        private List<SmartDevice> devices = new List<SmartDevice>();

        //public properties

        //method
        public void AddDevice(SmartDevice device)
        {
            // is there amy device in it 
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));

                // does the deviceID already exist in the list
                if (HasDevice(device.DeviceID))
                {
                    Console.WriteLine("ID already exists");
                    throw new ArgumentException($"This ID already exists, {device.DeviceID}");
                }
                devices.Add(device);
            }
        }

        
        public bool HasDevice(int deviceID)
        {
            int recordIndex = GetRecordIndex(deviceID);
            if (recordIndex == -1)
            {
                return false;
            }
            else 
            {
                return true;
            }

        }

        public int GetRecordIndex(int deviceID) 
        {
            for (int indexNo = 0; indexNo < devices.Count; indexNo++)
            {
                if (devices[indexNo].DeviceID == deviceID)
                {
                    return indexNo;
                }
            }

            return -1;
        }

        private void AddStarterDevices()
        {
            AddDevice(new SmartLight(50, "Warm White", 1, "Kitchen Light", true));
            AddDevice(new SmartSpeaker(30, false, 2, "Kitchen Speaker",true));
        }

        private void ShowMenu()
        { 
            Console.WriteLine();
            Console.WriteLine("==== Smart Home Menu =====");
            Console.WriteLine("1. Show all devices");
            Console.WriteLine("2.Remove one device");
            Console.WriteLine("0. Exit");
        }

        private int ReadChoice(String prompt, int min, int max) 
        {
            while (true)
            {
                Console.Write(prompt);
               String input = Console.ReadLine();

                if (!input.TryParsed(input, out int value))
                {
                    Console.WriteLine("Please enter a whole number.");
                }
                else if (value < min || value > max)
                {
                    Console.WriteLine($"Please enter a number between {min} and {max}");
                }
                else 
                {
                    return value;
                }
            }
        }

        public void showAllStatus() 
        {
            foreach (SmartDevice device in devices)
            { 
            device.GetStatus();
            }
        }

        private void RemoveOneDevice()
        { 
            int id = ReadWholeNumber("Device ID to remove: ");
            if (RemoveDevice(id) == true)
            {
                Console.WriteLine($"Device {ID} was removed }");

            }
            else
            {
                Console.WriteLine($"");
            }
        }

        private bool RemoveDevice()
        {
            int index = GetRecordIndex(deviceID);
            {
                if (index < 0)
                {
                    return false;

                }
            devices.RemoveAt(index);
                return true;
            }
        }

        private int ReadWholeNumber(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int parasedValue))
                { 
                    return parasedValue;
                }
                Console.WriteLine("Please enter a whole number");
            }
        }

        static void main(String[] args)
        {
            SmartHomeController controller = new SmartHomeController();
            controller.AddStarterDevices();
            controller.ShowMenu();
            bool running = true;
            while (running == true)
            {
                controller.ShowMenu();
                int menuChoice = ReadChoice("Please select a choice", 0, 1);

                switch (menuChoice)
                {
                    case 2:

                    case 1:
                        controller.ShowMenu();
                        break;
                    case 0:  
                        running = false; 
                        break;
                
                }


            }
        }
    }
}

