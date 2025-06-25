# [Propaganda TV (Continued)](https://steamcommunity.com/sharedfiles/filedetails/?id=3376039632)

![Image](https://i.imgur.com/buuPQel.png)

Update of Jellys mod https://steamcommunity.com/sharedfiles/filedetails/?id=2626812928

![Image](https://i.imgur.com/pufA0kM.png)
	
![Image](https://i.imgur.com/Z4GOv8H.png)

# TLDR:

[List]
- Passively reduces a newly recruited pawns certainty in their current Ideology if it is not the primary Ideology of the colony. (This will typically be the one you chose upon creation of your playthrough)
-  Does not effect prisoners in Prison Cells.
-  If a pawn already believes in the Colony's Primary Ideology, Reinforces belief in the primary colony's Ideology. 
-  Small short term mood buff (+5 for 5hrs) 
-  If Certainty reaches a low enough point, pawn will automatically convert to the colony's primary Ideology. 
-  Highly Compatible since it works via adding a comp to a powered Radio or TV. 
[/List]

![Image](https://i.imgur.com/b6KCbON.png)

Brainwash your new recruits!

This mod is inspired by/heavily based on Pelador's Mod TVforPrison (and Mlie now that Pelador has retired from modding.

# What does it do?


If a colonist is healthy, awake, not dead, burning, generally of good mind and body, and within a range of a Television or Radio, their beliefs start to waiver. As their belief in their ideology gets lower and lower, the effect lessens but can still convert the colonist to your primary Ideology. (This generally will be the one you've picked at the start of your game, unless something has gone horribly wrong ;) ) 

Things that effect the function of this mod:
The colonist must be alive and awake, able to see and hear.
Television and Radio type have different radius and effect factors! 
Be within a certain radius of the television or radio. 
More effective with colonists mood being higher.

Save Game compatible. Add or remove anytime.

No research needed.

Functionality can be added to modded tv's or *radio's. 

# How [Rimpropaganda](https://steamcommunity.com/sharedfiles/filedetails/?id=2624007189) is different:

PebbleCat made a very similar mod around the same time, that takes a more active approach. Be sure to check it out!

[quote=PebbleCat]Just wanted to add some more info about the differences from RimPropaganda.
It adds propaganda art as well, and requires TV to be set to a propaganda.
It requires the pawns be watching a TV, not just in range.
RimPropaganda is not affected by colonist mood.
It causes a mood debuff for pawns being converted.
It also reinforces existing beliefs for pawns already converted.[/quote]


![Image](https://i.imgur.com/GNHzLmd.png)

Now has basic support for Radios. The radio must have "radio" in the description to be considered a valid radio.  
Compatible with TVforPrison!
Now compatible with WallStuff!
Place after RimFlix.

# Supported Mods

[List]
- Wall Stuff
[List]
-  Wall Mounted Hifi
-  Small Wallscreen Television
-  Wallscreen Television
[/List]
- Vanilla Furniture Expanded
[List]
- Ultrascreen Television
- Industrial Radio
- Long Wave Radio
[/List]
[/List]
![Image](https://i.imgur.com/DPSE2aV.png)

It's probably gonna need balancing. Feedback is STRONGLY encouraged. 
Here's how it currently figures out how much to reduce/gain.

# Current Balance.

Currently this is set to run every 1000 ticks, approx every 16 seconds on normal speed. 
There are several factors effecting the final reduction/gaining of certainty, Tech Level, Mood, Sight, Hearing.
I'll break it down the best I can explain: 
You start with a factor of 1. (Since certainty is 0-1)
Mood * TV Effect Factor - multiplied by sight, then hearing - Multiplied by Tech Level

Then the final calculation: Certainty divided by 10, multiplied by the result of the above calculations. 

Also, because as certainty falls, the math gets into smaller and smaller numbers, it makes the final certainty reduction take longer. 

After all these calculations, it compares the result to .25 and whichever is smaller is used. This means you will NEVER get more than a .25 reduction in certainty. This will almost always be smaller than .25 anyway but the .25 limit is a sanity check. It sounds like a good chunk at a time, but remember, a pawn has a gain in their ideology passively due to mood, so we needed to compensate for when they weren't hearing the Propaganda. 

![Image](https://i.imgur.com/V1bOs7X.png)

(CC BY-NC-SA 4.0)
Credit to Pelador and Mlie for creating and maintaining respectively.

![Image](https://i.imgur.com/PwoNOj4.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using [HugsLib](https://steamcommunity.com/workshop/filedetails/?id=818773962) or the standalone [Uploader](https://steamcommunity.com/sharedfiles/filedetails/?id=2873415404) and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.
-  Use [RimSort](https://github.com/RimSort/RimSort/releases/latest) to sort your mods

 

[![Image](https://img.shields.io/github/v/release/emipa606/PropagandaTV?label=latest%20version&style=plastic&color=9f1111&labelColor=black)](https://steamcommunity.com/sharedfiles/filedetails/changelog/3376039632) | tags:  propaganda,  ideology conversion
