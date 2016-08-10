# What is this repository for?

This repository was used to teach a primer AI (artificial intelligence) prototyping course in **Unity 5.4** at Playcrafting NYC.

## Our AI Framework

We've created a wrapper that derives from Unity's `StateMachineBehavior` called `BehaviorAI`.

As such, instead of implementing Unity's

+ `OnStateEnter(...)`
+ `OnStateUpdate(...)`
+ `OnStateExit(...)`

you will be implementing

+ `OnBehaviorStart()` -> Called in `OnStateEnter(...)`
+ `OnBehaviorUpdate()` -> Called in `OnStateUpdate(...)`
+ `OnBehaviorEnd()` -> Called in `OnStateExit(...)`