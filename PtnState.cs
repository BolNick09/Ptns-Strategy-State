using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptns_Strategy_State
{
    enum OvenState
    {
        OFF = 0,
        ON,
        TIMER,
        ERRSTATE
    }
    internal class Oven 
    {
        OvenState state = OvenState.OFF;
        public void interact()
        {
            bool isWorking = true;
            int task;
            while (isWorking)
            {
                switch (state)
                {
                    case OvenState.OFF:
                    {
                        Console.WriteLine("Духовка выключена\n" +
                                          "Включить или включить с таймером: 0 - включить, 1 - включить с таймером");
                        
                        Int32.TryParse(Console.ReadLine(), out task);                        
                        switch (task)
                        {
                            case 0:
                            {
                                state = OvenState.ON; 
                                break;
                            }
                            case 1:
                            {
                                state = OvenState.TIMER;       
                                break;
                            }
                            default:
                            {
                                state = OvenState.ERRSTATE;
                                break;
                            }
                        }
                        break;
                    }
                    case OvenState.ON:
                    {
                        Console.WriteLine("Духовка включена, температура от 180 до 240 градусов Цельсия\n" +
                                          "Выключить или включить с таймером: 0 - выключить, 1 - включить с таймером");

                        Int32.TryParse(Console.ReadLine(), out task);
                        switch (task)
                        {
                            case 0:
                            {
                                state = OvenState.OFF;
                                break;
                            }
                            case 1:
                            {
                                state = OvenState.TIMER;
                                break;
                            }
                            default:
                            {
                                state = OvenState.ERRSTATE;
                                break;
                            }
                        }
                        break;
                    }
                    case OvenState.TIMER:
                    {
                        Console.WriteLine("Духовка включена, таймер на 5 секунд, температура от 180 до 240 градусов Цельсия");
                        Thread.Sleep(5000);
                        state = OvenState.OFF;
                        break;
                    }
                    case OvenState.ERRSTATE:
                    {
                        Console.WriteLine("Неверная команда, выход из программы");
                        isWorking = false;
                        break;
                    }
                }
            }
        }

    }
}
