# PS-POLY

🔧 **PS-POLY** is a tool that converts **Yukes’ YOBJ file (PSP version)** into a **Wavefront OBJ** format, making it viewable and editable in standard 3D modeling tools.

## 🗂️ Purpose

This tool was designed to support the modding community by enabling easier access to 3D models extracted from Yukes’ games on the PSP platform, such as WWE SmackDown vs. Raw.

## 📅 Development Timeline

- **Created:** 23rd July 2016
- **Completed:** 17th March 2024

## 🚀 Features

- Converts YOBJ files (PSP) into .OBJ format.
- Compatible with most 3D modeling tools (e.g., Blender, Maya).
- Maintains model structure for easier editing.

## 📥 Installation & Usage

1. Clone the repository:
   ```bash
   git clone https://github.com/TomD554/PS-POLY.git

2. Open the application executable (located in bin/debug)

3. Open the sample yobj file

4. Export any object of your choice (for example's sake Object0)

5. Load the output .obj files in your preferred 3D modeling software.

6. (IF EDITED OBJ FILE), inject it back into its respective slot

SOME RULES FOR INJECTING EDITED OBJ FILES-

1. Cannot have added vertices to the model, it won't inject back into the slot

2. Faces injection has partial support, for smaller models with 4-8 vertices, so don't mess with face connections in the models with higher vertex counts

3. UV injection is also partially supported, for smaller models with 4-8 vertices