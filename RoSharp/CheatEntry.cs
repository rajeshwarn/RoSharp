﻿using System;
using System.Diagnostics;
using RoSharp.Memory;
using RoSharp.Roblox;

namespace RoSharp
{
    class CheatEntry
    {
        private static RobloxLua robloxLuaState;

        public CheatEntry(Process process) 
        {
            robloxLuaState = new RobloxLua(process, new IntPtr(0xB30000));
            
        }

        public void Initialize()
        {
            ////printidentity
            robloxLuaState.SetIdentity(6);
            robloxLuaState.GetGlobal("spawn");
            robloxLuaState.GetGlobal("printidentity");
            robloxLuaState.Call(1, 0);

            ////example forcefield
            robloxLuaState.GetGlobal("Instance");
            robloxLuaState.GetField(-1, "new");
            robloxLuaState.PushString("ForceField");
            robloxLuaState.Call(1, 1);

            robloxLuaState.GetGlobal("game");
            robloxLuaState.GetField(-1, "Players");
            robloxLuaState.GetField(-1, "LocalPlayer");
            robloxLuaState.GetField(-1, "Character");
            robloxLuaState.SetField(-5, "Parent");


            robloxLuaState.PushString("new string");
            Console.WriteLine(robloxLuaState.ToString(-1));

            //char.Humanoid.Health = 500
            //test
        }
    }
}
