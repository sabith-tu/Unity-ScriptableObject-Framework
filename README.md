# Sabi-Unity-ScriptableObject-Framework



What is this : 
<ul> <li>This is a scriptable object architecture / framework / pattern for unity inspired by "Unite Austin 2017 - Game Architecture with Scriptable Objects". Build your game on top of this layer for a far better developer experience</li></ul>

How to setup :
<ul>
  <li>If you want to start as a fresh project : download full project and open with unity hub</li>
  <li>If you want to add it to existing project : download Project folder from Assets and drag and drop it to your project </li>
</ul>

How to use it :
<ul>
  <li>Right click on project window -> Create -> So -> to access all scriptable objects</li>
  <li>On inspect window -> add component -> _SABI -> to access most of the components. ( some components are not available from here )</li>
</ul>

What are the primary areas that require attention and improvement :
<ul> <li>This project have a dependency on odin inspector. All of the editor script need to be converted to UI Tool kit </li></ul>

Whats included : 
<ul>
  <li> Scriptable object variables with change notifier </li>
  <li> Trigger scripts: to start an action based on multiple events </li>
  <li> Event system </li>
  <li> Action script: to execute multiple predefined actions </li>
  <li> Flow control: control the flow of execution </li>
  <li> Quich actions: create and execute some repeated actions without without new game object or scripts </li>
  <li> Simple state machine </li>
  <li> Simple animation controller </li>
  <li> Save load system </li>
  <li> And much much more ... </li>
</ul>

```diff

- Important: This project have a dependency on odin inspector.

```
 The installation of Odin Inspector is a prerequisite for the proper functioning of the editor scripts; failure to do so will result in 750+ errors.
