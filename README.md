[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<br />
<br />
<p align="center">
  <a href="https://github.com/deSp44/MyCalendar">
    <img src="https://user-images.githubusercontent.com/56117577/124885463-92dd4400-dfd3-11eb-8bbe-29e3fa2439a5.png" alt="Logo" width="300" height="77">
  </a>
  
  <h3 align="center">MyCalendar</h3>
  <p align="center">
    A simple console calendar in which you can manage your time and tasks!
    <br />
    <a href="https://github.com/deSp44/MyCalendar"><strong>Explore the docs »</strong></a>
	·
    <a href="https://github.com/deSp44/MyCalendar/issues">Report Bug</a>
	·
    <a href="https://github.com/deSp44/MyCalendar/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
		    <li><a href="#executing-program">Executing program</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <ul>
        <li><a href="#introdution">Introdution</a></li>
		    <li><a href="#show-calendar">Show calendar</a></li>
        <li><a href="#show-tasks">Show tasks</a></li>
        <li><a href="#add-new">Add new...</a></li>
        <li><a href="#edit">Edit...</a></li>
        <li><a href="#delete">Delete...</a></li>
      </ul>
    <li><a href="#contributing">Contributing</a></li>
	<li><a href="#help">Help</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project
This project was designed to create a simple manager of your time. You can add your events to separate calendars so you can organize all kinds of parts of your life. Additionally, for each day, you can create a to-do list that you can check off so that none of the daily challenges will be missed. And it's all saved locally on your computer.

### Built With
* [Visual Studio 2019](https://visualstudio.microsoft.com/pl/vs/)
* [C# 9.0](https://docs.microsoft.com/pl-pl/dotnet/csharp/whats-new/csharp-9)
* [.NET Core 5](https://docs.microsoft.com/pl-pl/dotnet/core/dotnet-five)
* [LINQ](https://docs.microsoft.com/pl-pl/dotnet/api/system.linq?view=net-5.0)
* [XmlSerializer](https://docs.microsoft.com/pl-pl/dotnet/api/system.xml.serialization.xmlserializer?view=net-5.0)

<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Installation
Clone the repo from git
   ```sh
   git clone https://github.com/deSp44/MyCalendar.git
   ```
   or
   
In Visual Studio, just paste the link in the "Clone a repository" section
   ```sh
   https://github.com/deSp44/MyCalendar.git
   ```
   
### Executing program
Just build solution using the Ctrl + Shift + B shortcut or by right-clicking the solution and the "Build Solution" option. After that the .exe file will be waiting for you in the bin folder.

<!-- USAGE EXAMPLES -->
## Usage

### Introdution
After starting the program, the user is presented with the main menu.
<p align="center">
  <img src="https://user-images.githubusercontent.com/56117577/124899066-0b4a0200-dfe0-11eb-9b07-583a9c958c0a.png" />
</p>
The selection is made with one click of the button.

### Show calendar
This option simply displays all of your events sorted by date, broken down into calendars, and whether it's been over.
<p align="center">
  <img src="https://user-images.githubusercontent.com/56117577/124915426-ce870680-dff1-11eb-88af-402cf9125a23.png" />
</p>

### Show tasks
In the menu that appears, you can show all tasks, or choose to check or uncheck the task completion.
<p align="center">
  <img src="https://user-images.githubusercontent.com/56117577/124913791-d645ab80-dfef-11eb-812a-d15babc08cc3.png" />
</p>

All tasks are displayed with a day-to-day breakdown and execution status.
<p align="center">
  <img src="https://user-images.githubusercontent.com/56117577/124913811-dba2f600-dfef-11eb-9879-f8826d41dd3c.png" />
</p>

To change the status of a task, select the number assigned to the task and then confirm the operation with the "Y" key.
<p align="center">
  <img src="https://user-images.githubusercontent.com/56117577/124913833-e65d8b00-dfef-11eb-9ed1-37347a67ef02.png" />
</p>

### Add new...
In the menu that appears, you can select the type of item to add, then depending on the selected element, you will be asked to enter the appropriate data. Pay attention to the given formatting, e.g. date: DD-MM-YYYY.
<p align="center">
  <img src="https://user-images.githubusercontent.com/56117577/124916697-3e49c100-dff3-11eb-8823-9c2b332fdccf.png" />
</p>
After entering the appropriate data confirm the operation with the "Y" key.

### Edit...
In the menu that appears, you can select the type of item to edit, and then the specific item. You will have to enter the values again to change them. Above, however, there will be listed data that is changed in order to facilitate their editing.
<p align="center">
  <img src="https://user-images.githubusercontent.com/56117577/124919094-17d95500-dff6-11eb-8171-8d69304579c0.png" />
</p>
<p align="center">
  <img src="https://user-images.githubusercontent.com/56117577/124919098-190a8200-dff6-11eb-9ef3-a0f03a4aa84c.png" />
</p>

After entering the new data confirm the operation with the "Y" key.

### Delete...
In the menu that appears, you can select the type of item to delete, then the specific item and confirm the entire operation with the "Y" key.
<p align="center">
  <img src="https://user-images.githubusercontent.com/56117577/124914146-4ce2a900-dff0-11eb-95b5-e13484221991.png" />
</p>
<p align="center">
  <img src="https://user-images.githubusercontent.com/56117577/124915670-19a11980-dff2-11eb-9800-c72444f298f1.png" />
</p>

The "Everything" option deletes all your saved data (after this operation it will not be possible to recover it anymore, so use it carefully!).
<p align="center">
  <img src="https://user-images.githubusercontent.com/56117577/124914139-4a804f00-dff0-11eb-8744-1331290d7938.png" />
</p>

<!-- CONTRIBUTING -->
## Contributing
Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<!-- HELP -->
## Help

#### Where are my saves stored?
Your calendar and task data files are stored in your user directory in the AppData folder.
The path to them should look like this:
```sh
   C:\Users\your_username\AppData\Roaming\MyCalendarData
```

<!-- LICENSE -->
## License
Distributed under the MIT License. See `LICENSE` for more information.

<!-- CONTACT -->
## Contact
Michał Czaja
<br />
LinkedIn : [Michał Czaja](https://pl.linkedin.com/in/micha%C5%82-czaja-735013209)
<br />
Twitter : [@deSp_97](https://twitter.com/deSp_97)
<br />
Stack Overflow : [deSp](https://stackoverflow.com/users/15499426/desp)
<br />
Project Link: [https://github.com/deSp44/MyCalendar](https://github.com/deSp44/MyCalendar)



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/deSp44/MyCalendar.svg?style=for-the-badge
[contributors-url]: https://github.com/deSp44/MyCalendar/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/deSp44/MyCalendar.svg?style=for-the-badge
[forks-url]: https://github.com/deSp44/MyCalendar/network/members
[stars-shield]: https://img.shields.io/github/stars/deSp44/MyCalendar.svg?style=for-the-badge
[stars-url]: https://github.com/deSp44/MyCalendar/stargazers
[issues-shield]: https://img.shields.io/github/issues/deSp44/MyCalendar.svg?style=for-the-badge
[issues-url]: https://github.com/deSp44/MyCalendar/issues
[license-shield]: https://img.shields.io/github/license/deSp44/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/deSp44/MyCalendar/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/micha%C5%82-czaja-735013209/
