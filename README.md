# CSE-539-Applied-Cryptography-2021-Fall-B

## Binder
<!-- [![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/GiveThanksAlways/CSE-539-Applied-Cryptography-2021-Fall-B/HEAD) -->

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/GiveThanksAlways/interactive/HEAD)

![image](https://user-images.githubusercontent.com/7727291/136446547-cd2f51a7-5e42-46d0-b275-8c8b9c820fe5.png)

* helpful link for .NET interactive notebooks: [https://github.com/dotnet/interactive](https://github.com/dotnet/interactive)
* microsoft blog post [https://github.com/dotnet/interactive](https://github.com/dotnet/interactive)

## :gear: :hammer: Setup Guides

#### Technology Requirements (.NET Core 3.1)
You can use .NET Core 3.1 or .NET 5 (or anything up from .NET 5). The autograder uses .NET Core 3.1 but the only thing you have to change in your submission is the `.csproj` config file. See the note at the end of the README about how to submit if you are not using .NET Core 3.1 for local development.


* [Windows](./gettingStarted/Windows)
* [Mac OS](./gettingStarted/Mac)
* [Docker](./gettingStarted/Docker)
* [WSL (Windows subsystem for linux)](./gettingStarted/Windows-WSL)

## :earth_americas: :world_map: Project Guides
* [P1_1](./projectGuides/P1_1)
* [P1_2](./projectGuides/P1_2)
* [P2](./projectGuides/P2)
* [P3](./projectGuides/P3)
* [P4](./projectGuides/P4)

##### Other examples
* [input example](./projectGuides/inputExample)
* [.csproj](./gettingStarted/SubmitProjectExample/P2.csproj)

## :white_check_mark: :white_check_mark: Submitting Your Project

> Note: You can remove the bin and obj folders in your submission if you prefer to. You can pass the autograder by just submitting the [`.csproj`](./gettingStarted/SubmitProjectExample/P2.csproj) file and the `Program.cs` file.

* Make sure your code is located in the folder that is named correctly for that project (example: P2 for project 2) and make sure it is not nested inside of other folders. 
    * When the autograder unzip's the zipped project folder, it should see the `Program.cs` file and the `.csproj` file. (The bin and obj folders will be there as well) 
    * **recommended**:
         * ![image](https://user-images.githubusercontent.com/7727291/136249276-b2f8a531-598b-4752-a49f-fe1f795377d2.png)
    * optional: 
         * ![image](https://user-images.githubusercontent.com/7727291/130523217-0b382a36-8f7b-4a3a-a9a9-c3efd5b331f9.png)
* Zip the project folder and submit it to be graded
    * ![image](https://user-images.githubusercontent.com/7727291/130523286-e4b7eb8e-8724-471e-a1d3-864f529ab287.png)
    * ![image](https://user-images.githubusercontent.com/7727291/130523537-e5a5f7da-283c-445e-8a97-cab327a1d54e.png)
* Now you can submit this `.zip` file to be graded
 



## Non .NET Core 3.1 Development
You can build the projects using a version newer that 3.1 (or using .NET 5 and up which replaces both .NET core and .NET framework). The only thing you should have to do is change the target platform in the `*.csproj` file when you submit the project. The `<TargetFramework>` tags should look like the following:
```
<TargetFramework>netcoreapp3.1</TargetFramework>
```

> NOTE: If you change the target framework it will not run locally (unless you do some extra setup). So after you submit the project you should switch it back to what it was before to continue testing your code locally. And again, this only applies if you are not developing locally with .NET Core 3.1
