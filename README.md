# What is this repository for?

This repository was used to teach a primer AI (artificial intelligence) prototyping course in **Unity 5.4** at Playcrafting NYC.
Eventually this repository will be repurposed to be a framework for everyone to use. It's open sourced so feel free to use it!

## Our AI Framework

We've created a wrapper that derives from Unity's `StateMachineBehavior` called `BehaviorAI`, which follows
a _psuedo state machine_ system.

As such, instead of implementing Unity's

+ `OnStateEnter(...)`
+ `OnStateUpdate(...)`
+ `OnStateExit(...)`

you will be implementing

+ `OnBehaviorStart()` -> Called in `OnStateEnter(...)`
+ `OnBehaviorUpdate()` -> Called in `OnStateUpdate(...)`
+ `OnBehaviorEnd()` -> Called in `OnStateExit(...)`

The idea behind this is to think in terms of your game design sense and not always so technically or programatically.

## How do I set up this repository?
For now just simply clone the repository or download it as a zip file, I'll be migrating this repo to be less of a tutorial and more
of a framework over the next few weeks.

## Feature Requests and Bug Reporting
Simply drop an issue in Github's issue tracker or email me (you can find my email address on my profile).

## TODOs
 - [ ] Set up Wiki for documentation and API
 - [ ] Provide a custom editor for the AI brain to make it easier to debug
 - [ ] Provide tutorials of different complexities (3D and 2D)
 - [ ] Rename repo