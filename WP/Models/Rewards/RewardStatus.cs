using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models.Rewards {

    public enum RewardStatus {
        Null = 0,

        // This is the initial state of a newly issued reward.
        Unseen = 1,

        // This state happens when the reward has been seen by the receiving party.
        ViewedNewReward = 3

    } // enum RewardStatus 
    
} // namespace WP.Common.Models.Rewards