# Scene creator tool

The scene creator tool allows us to created new scenes with ease.\
It will create a new scene, terrain data and new StaticObject scene if the base scene has one.   

## Open the tool

To open the scene creator tool you have to click on the NeoN tab from there you can select the scene creator tool and start using it.  

![SceneCreatorToolSelect](https://github.com/BAStudio/OperationStarfall/assets/90682539/6d505453-36cd-4182-9035-bce91a7ba898)

## How to use the tool

When the tool has been opened you can use the tool by
1.  Naming the new scene
2. Selecting a folder for the new scene
3. Selecting one of the scene templates
4. Press the "Create scene" button

## Errors

The Scene creator has 2 potential errors which are:
1. Name field cannot be empty\
which means the name field does not contain any characters
2. Scene already exists\
which means the scene already exist in the given location. this gives an additional 2 responses
> 1. Replace scene\
Which replaces the existing scene with the template
> 2. Open scene\
Which opens the existing scene

## Scene templates

All scene templates can be found at Assets/Scenes/templates\
Scene templates are all the .unity files found in this location except files that contain "StaticObjects"\
The scene template can be selected at the "Base Template" field 

### Creating new template

Creating a new template is as easy as going to Assets/Scenes/templates and creating a new scene\
Or using the tool and selecting the templates map as scene map\
![CreateNewSceneTemplate](https://github.com/BAStudio/OperationStarfall/assets/91124861/e2354cc1-5177-4cf8-8d13-2fee78f38803)