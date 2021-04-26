using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public interface IWorldSectionHotSpot
{
    void Activate();
    void Deactivate();
}

public abstract class WorldSectionHotSpotBase : MonoBehaviour, IWorldSectionHotSpot
{
    public abstract void Activate();
    public abstract void Deactivate();
}
