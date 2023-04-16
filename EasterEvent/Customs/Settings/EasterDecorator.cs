using Kitchen;
using Kitchen.Layouts;
using KitchenData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EasterEvent.Customs.Settings
{
    public class EasterDecorator : Decorator
    {
        public override bool Decorate(Room room)
        {
            DecorationsConfiguration decorationsConfiguration = Configuration as DecorationsConfiguration;
            bool flag = decorationsConfiguration != null;
            bool result;
            if (flag)
            {
                Bounds bounds = Blueprint.GetBounds();
                Vector3 frontDoor = Blueprint.GetFrontDoor();
                NewPiece(decorationsConfiguration.Ground, 0f, 0f);
                for (float num = bounds.min.x - 4f; num <= bounds.max.x + 4f; num += 1f)
                {
                    foreach (DecorationsConfiguration.Scatter scatter in decorationsConfiguration.Scatters)
                    {
                        bool flag2 = UnityEngine.Random.value < scatter.Probability;
                        if (flag2)
                        {
                            NewPiece(scatter.Appliance, num, bounds.min.y - 6f);
                        }
                        bool flag3 = UnityEngine.Random.value < scatter.Probability;
                        if (flag3)
                        {
                            NewPiece(scatter.Appliance, num, bounds.max.y + 3f);
                        }
                    }
                }
                for (float num2 = bounds.min.y - 2f; num2 <= bounds.max.y + 2f; num2 += 1f)
                {
                    foreach (DecorationsConfiguration.Scatter scatter2 in decorationsConfiguration.Scatters)
                    {
                        bool flag4 = num2 > bounds.min.y && UnityEngine.Random.value < scatter2.Probability;
                        if (flag4)
                        {
                            NewPiece(scatter2.Appliance, bounds.min.x - 3f, num2);
                        }
                        bool flag5 = UnityEngine.Random.value < scatter2.Probability;
                        if (flag5)
                        {
                            NewPiece(scatter2.Appliance, bounds.max.x + 4f, num2);
                        }
                    }
                }
                bool flag6 = decorationsConfiguration.Cobblestone != null;
                if (flag6)
                {
                    for (float num3 = PathStartLocation; num3 <= (float)-(float)PathStartLocation; num3 += 0.8f)
                    {
                        NewPiece(decorationsConfiguration.Cobblestone, num3, bounds.min.y - 1.2f);
                    }
                }
                bool flag7 = decorationsConfiguration.Fencing != null;
                if (flag7)
                {
                    for (float num4 = bounds.min.x - 15f; num4 <= bounds.max.x + 15f; num4 += decorationsConfiguration.BorderSpacing)
                    {
                        bool flag8 = num4 >= bounds.min.x && num4 <= bounds.max.x;
                        if (!flag8)
                        {
                            NewPiece(decorationsConfiguration.Fencing, num4, bounds.min.y - 0.7f);
                        }
                    }
                }
                for (float num5 = bounds.min.x - 1f; num5 <= bounds.max.x + 1f; num5 += 1f)
                {
                    NewPiece(AssetReference.OutdoorMovementBlocker, num5, bounds.min.y - 3f);
                }
                float x = frontDoor.x < 3f ? frontDoor.x + 1f : frontDoor.x - 1f;
                NewPiece(AssetReference.Nameplate, x, bounds.min.y - 1f);
                NewPiece(AssetReference.OutdoorMovementBlocker, bounds.min.x - 1f, bounds.min.y - 1f);
                NewPiece(AssetReference.OutdoorMovementBlocker, bounds.min.x - 1f, bounds.min.y - 2f);
                NewPiece(AssetReference.OutdoorMovementBlocker, bounds.max.x + 1f, bounds.min.y - 1f);
                NewPiece(AssetReference.OutdoorMovementBlocker, bounds.max.x + 1f, bounds.min.y - 2f);
                NewPiece(Profile.ExternalBin, frontDoor.x, frontDoor.z - 3f);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        private int PathStartLocation = -20;

        public class DecorationsConfiguration : IDecorationConfiguration
        {
            public IDecorator Decorator
            {
                get
                {
                    return new EasterDecorator();
                }
            }

            public List<Scatter> Scatters;

            public Appliance Cobblestone;

            public Appliance Fencing;

            public float BorderSpacing;

            public Appliance Ground;

            public struct Scatter
            {
                public float Probability;

                public Appliance Appliance;
            }
        }
    }
}
