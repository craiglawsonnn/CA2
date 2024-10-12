# Activity Management Application
## Project Overview
This project is a WPF (Windows Presentation Foundation) application that allows users to manage a list of activities based on different categories such as Land, Water, and Air. Users can filter, select, and move activities between available and selected lists while keeping track of the total cost of selected activities. The application also ensures that users cannot select activities that occur on the same date, preventing scheduling conflicts.

## Features
- Filter Activities by Category: Users can filter activities by Land, Water, or Air categories using radio buttons.
- Activity Selection: Users can select available activities and move them to a "Selected Activities" list.
- Date Conflict Handling: The application checks for date conflicts and prevents users from selecting multiple activities on the same date.
- Total Cost Calculation: The application dynamically updates the total cost of selected activities.
- User-Friendly Interface: The application provides easy navigation with radio buttons, list boxes, and buttons for selecting and managing activities.
# Technologies Used
- Language: C#
- Framework: WPF (Windows Presentation Foundation)
- IDE: Visual Studio
- Design Patterns: MVVM (Model-View-ViewModel) is used implicitly with WPF data binding for handling the UI updates with ObservableCollection.

# How It Works
- Activity List Management: The application creates a list of activities upon loading, with each activity having a name, date, cost, description, and type (Land, Water, Air).
- Filtering: Users can filter activities by their type (Land, Water, Air) using radio buttons. The application updates the displayed activities accordingly.
- Selection: Users can move activities between the available list (lbxAllActivities) and the selected list (lbxSelectedActivities) using buttons. When an activity is selected, the total cost is updated, and any scheduling conflicts (same date) are avoided.
- Activity Description: When an activity is selected from the list, its description is displayed in the UI.
# Usage
Prerequisites
Visual Studio or any other C# IDE with .NET Framework support.
Running the Application
Clone the repository:
```bash
git clone https://github.com/craiglawsonnn/CA2.git
```
Open the project in Visual Studio.
Build and run the application. The WPF interface should load, allowing you to manage activities by filtering and selecting them.
# Key UI Components:
- Radio Buttons: Filter activities by category (Land, Water, Air).
- List Boxes: Display available and selected activities.
- Buttons: Move activities between the lists and update the total cost.
- Text Blocks: Display activity descriptions and the total cost of selected activities.
