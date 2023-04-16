using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;

namespace EasterEvent.Customs.Cards
{
	public class EasterCard : CustomUnlockCard
	{
		public override string UniqueNameID => "EasterCard";
		public override List<UnlockEffect> Effects => new List<UnlockEffect>
		{
			new GlobalEffect
			{
				EffectCondition = new CEffectAlways(),
				EffectType = new CTableModifier
				{
					OrderingModifiers = new OrderingValues
					{
						RepeatCourseModifier = 0.25f,
						ChangeMindModifier = 0.1f
					}
				}
			},
			new StatusEffect
			{
				Status = (RestaurantStatus)VariousUtils.GetID("tripleordering")
			}
		};

		public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
		{
			(Locale.English, new UnlockInfo
			{
				Name = "Eggstra Special",
				Description = "Customers can order up to 3 times, Children make more mess, Customers can change their orders.",
				FlavourText = "It's Easter already!?"
			})
		};
		public override CardType CardType => CardType.Default;
		public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Large;
		public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
	}
}
