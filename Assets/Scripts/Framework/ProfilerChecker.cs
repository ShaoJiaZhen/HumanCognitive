
using System.Collections;
using System;
public class ProfilerChecker : IDisposable  {

    public ProfilerChecker(string name) {
        UnityEngine.Profiling.Profiler.BeginSample(name);
    }

    public void Dispose() {
        UnityEngine.Profiling.Profiler.EndSample();
    }
}
