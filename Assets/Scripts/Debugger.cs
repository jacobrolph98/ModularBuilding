using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to make it easier to deal with Logs once bugs are dealt with
/// Instead of going through code with Ctrl-F simply enable or disable at the top of the class it is used in
/// </summary>
public class Debugger
{
    public bool isEnabled;

    public Debugger(bool enabledByDefault)
    {
        isEnabled = enabledByDefault;
    }

    public void Log(object value, bool overrideEnabler = false)
    {
        if (isEnabled || overrideEnabler)
            Debug.Log(value);
    }
}
