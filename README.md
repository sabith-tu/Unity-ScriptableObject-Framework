# Unity-ScriptableObject-Framework

What is this : 
<ul> <li> Hello, my name is sabith and this is a Open-source scriptable object architecture / framework / pattern for unity game engine. Build your game on top of this layer for a far better developer experience</li></ul>

How to get started :
<ul>
  <li>Make sure you own odin inspector (it's a dependency for now) </li>
  <li> 
    <ul>
      <li>If you want to start as a fresh project : Download this full project and open with unity hub. Click on ignore option at the dialog box "Enter safe mode". After opening the project import odin to remove the errors </li>
      <li>If you want to add it to existing project : Make sure you have odin on the project. Download "_Project" folder from "Assets" and drag and drop it to your project </li>
    </ul> 
  </li>
  
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
  <li> Event system </li>
  <li> Trigger scripts: to start an action based on multiple events </li>
  <li> Action script: to execute multiple predefined actions </li>
  <li> Flow control: control the flow of execution </li>
  <li> Quich actions: create and execute some repeated actions without without new game object or scripts </li>
  <li> Optimized code with Assembly Definitions </li>
  <li> Simple state machine </li>
  <li> Simple animation controller </li>
  <li> Save load system </li>
  <li> And much much more ... </li>
</ul>

```diff

- Important: This project have a dependency on odin inspector.

```
 The installation of Odin Inspector is a prerequisite for the proper functioning of the editor scripts; failure to do so will result in 750+ errors.
