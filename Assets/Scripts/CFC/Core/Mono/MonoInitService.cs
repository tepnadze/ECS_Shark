using System;
using System.Collections.Generic;

public class MonoInitService : IDisposable 
{
    private readonly List<MonoBase> mono_list = new List<MonoBase>();

    public void subscribe(MonoBase mono)
    {     
        if (!mono_list.Contains(mono)) 
            mono_list.Add(mono);       
    }

    public void deSubscribe(MonoBase mono)
    {
        if (mono_list.Contains(mono))
            mono_list.Remove(mono);       
    }

    public void initMono() {

        for (int i = 0; i < mono_list.Count; i++) {
            mono_list[i].init();
        }
    }

    public void Dispose()
    {
        mono_list.Clear();
    }
}
