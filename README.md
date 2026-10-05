<div align="center">

# 🔪 CouteauSuisse

**A pocket console toolkit for Windows: turn text into Morse code you can hear, convert numbers between bases, and more.**

[![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)](#)
[![.NET 9](https://img.shields.io/badge/.NET-9-512BD4?style=flat&logo=dotnet&logoColor=white)](#)
[![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?style=flat&logo=windows&logoColor=white)](#)
[![Interface](https://img.shields.io/badge/Interface-Fran%C3%A7ais-blue?style=flat)](#)
[![License](https://img.shields.io/badge/License-MIT-lightgrey?style=flat)](#)

<br>

[![Stars](https://img.shields.io/github/stars/RufusTheDwarf/CouteauSuisse?style=flat&color=yellow)](https://github.com/RufusTheDwarf/CouteauSuisse/stargazers)
[![Forks](https://img.shields.io/github/forks/RufusTheDwarf/CouteauSuisse?style=flat&color=blue)](https://github.com/RufusTheDwarf/CouteauSuisse/forks)
[![Issues](https://img.shields.io/github/issues/RufusTheDwarf/CouteauSuisse?style=flat&color=red)](https://github.com/RufusTheDwarf/CouteauSuisse/issues)
[![Last Commit](https://img.shields.io/github/last-commit/RufusTheDwarf/CouteauSuisse?style=flat&color=orange)](https://github.com/RufusTheDwarf/CouteauSuisse/commits/main)
[![Repo Size](https://img.shields.io/github/repo-size/RufusTheDwarf/CouteauSuisse?style=flat&color=black)](https://github.com/RufusTheDwarf/CouteauSuisse)

</div>

## 📖 Overview

**CouteauSuisse** is a single self-contained `.exe` for Windows. No installer, no runtime to download, no external dependencies. Double-click it, pick a tool from the menu, get your result, and either try again or quit.

The name says it all: a pocket knife for developers and curious minds. It brings together small, practical utilities that you would otherwise have to look up online, with a friendly French interface and a tone that keeps things simple.

The project targets **.NET 9.0** and is written entirely in **C#**, using only the standard library.

## ✨ Features

### 🔤 Text → Morse Code

Convert any text into International Morse Code and listen to it played back through your system speaker.

| Capability | Detail |
|---|---|
| **Supported letters** | `A–Z` (no accents) |
| **Supported digits** | `0–9` |
| **Supported punctuation** | `. , : ; ? ! - _ / ( ) & = + " ' $ @` |
| **Word separator** | `/` |
| **Letter separator** | space |
| **Audio** | System speaker, `800 Hz` tone |
| **Dot duration** | `200 ms` |
| **Dash duration** | `600 ms` |
| **Input validation** | Unsupported characters are rejected with a clear message and you are asked to retype |

### 🔢 Base Converter

A four-way converter that works on 32-bit integers. Invalid input is caught and reported instead of crashing the program.

| # | Conversion | Example |
|---|---|---|
| 1 | Decimal → Binary | `42` → `101010` |
| 2 | Binary → Decimal | `101010` → `42` |
| 3 | Binary → Octal | `101010` → `52` |
| 4 | Octal → Binary | `52` → `101010` |

### 🔐 Steganography *(in progress)*

A third tool is planned to hide and extract messages inside images. The menu and input handling are already in place, but the encoding and decoding logic is not yet implemented. This feature is considered **experimental** and may be removed or completed in a future release.

### 🖥️ The Menu

- A clean, centered header
- Input validation on every prompt
- Option to restart or quit after each action
- Room reserved for a third tool

## 🚀 Download

The fastest way to use CouteauSuisse is to grab the pre-built executable.

1. Head to the [**Releases**](https://github.com/RufusTheDwarf/CouteauSuisse/releases/latest) page.
2. Download the latest `.exe` from the release assets.
3. Double-click it, or launch it from a terminal.

> ⚠️ **Windows only.** The audio playback uses `Console.Beep` with a custom frequency, which is not supported on Linux or macOS. The base converter would work on other platforms, but the Morse audio would not.

**Quick links:** [Download](https://github.com/RufusTheDwarf/CouteauSuisse/releases/latest) · [Report an issue](https://github.com/RufusTheDwarf/CouteauSuisse/issues) · [View source](https://github.com/RufusTheDwarf/CouteauSuisse)

## 🖥️ Usage

### Main Menu

When you launch the executable, you are greeted with the main menu:

```text
╔═════════════════════════════════════╗
║                                     ║
║          Couteau suisse             ║
║                                     ║
╚═════════════════════════════════════╝

=== Couteau Suisse – Utilitaires ===
1. Convertir du texte en code Morse
2. Convertir des bases (Décimal, Binaire, Octal)
3. Stéganographie : encodage et décodage

Veuillez choisir une option :
```

Pick `1`, `2`, or `3` to access a tool.

### Morse Conversion

Select option `1`, then type any word or sentence using supported characters. The result is displayed and played back through your speaker.

```text
Entrez un mot ou une phrase : SOS
Résultat en Morse : ... --- ...

[Audio plays: dot dot dot, dash dash dash, dot dot dot]
```

If you type a character that is not supported (for example, an accented letter like `é`), the program explains the issue and asks you to try again — no crash, no lost session.

### Base Conversion

Select option `2`, then pick the conversion you need:

```text
=== Convertisseur de bases ===
1. Décimal > Binaire
2. Binaire > Décimal
3. Binaire > Octal
4. Octal > Binaire

Veuillez choisir une option : 1
Veuillez entrer un nombre : 42
Résultat : 101010
```

After each conversion, you can convert another number or return to the main menu.

### Steganography *(placeholder)*

Select option `3`. The menu and input prompts are shown, but no actual encoding or decoding happens yet. This is a work in progress.

## 🔊 How the Morse Audio Works

The audio playback relies on the .NET `Console.Beep(frequency, duration)` method, which sends a tone directly to the system speaker. Each dot is a `200 ms` tone, each dash is `600 ms`, and letters are spaced by silence.

This is why the tool is **Windows-only**: the `Console.Beep` overload with a custom frequency is not supported on Linux or macOS, where the call either throws or produces no sound.

## 🛠️ Build from Source

If you want to modify the code or build the executable yourself, you will need the [**.NET 9.0 SDK**](https://dotnet.microsoft.com/download/dotnet/9.0).

### Run in development mode

```bash
git clone https://github.com/RufusTheDwarf/CouteauSuisse.git
cd CouteauSuisse
dotnet run
```

### Build a single-file executable

```bash
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

The resulting `.exe` will be in:

```text
bin/Release/net9.0/win-x64/publish/
```

You can copy that file anywhere — it contains everything it needs to run.

**Get the tools:** [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) · [Git](https://git-scm.com/downloads) · [VS Code](https://code.visualstudio.com/)

## 📁 Project Structure

```text
CouteauSuisse/
│
├── en-cours/                    # Active program (menu, Morse, base converter, steganography)
│   └── CouteauSuisse.cs
│
├── anciennes versions/          # Earlier iterations, excluded from the build
│
├── convertisseur-de-baseV4.cs   # Standalone base converter, excluded from the build
│
├── jdt                          # Work journal
│
├── morse.csproj                 # .NET project file
│
├── .gitignore
│
├── LICENSE
│
└── README.md
```

The active program lives in `en-cours/`. The `anciennes versions/` folder keeps the history of earlier iterations, and `convertisseur-de-baseV4.cs` is a standalone snapshot of the base converter before it was merged into the main tool. Only `en-cours/` is compiled.

## 🗺️ Roadmap

- [x] Text → Morse with audio playback
- [x] Four-way base converter
- [x] Input validation and error handling
- [x] Single-file executable
- [ ] Complete the steganography module
- [ ] Support for accented characters in Morse mode
- [ ] Adjustable audio speed
- [ ] Save conversions to a log file
- [ ] English interface option

> Have an idea for a new tool? [Open an issue](https://github.com/RufusTheDwarf/CouteauSuisse/issues) and share it.

## ⚠️ Known Issues

- **Steganography is incomplete.** The menu exists but the encoding and decoding logic is missing.
- **Non-numeric input in the base converter** can throw a `FormatException` in some paths.
- **Accented characters are not supported** in Morse mode. The user is asked to retype.
- **Audio playback blocks the thread.** The program pauses while the Morse code plays.
- **Windows only.** The Morse audio feature does not work on Linux or macOS.

## 🤝 Contributing

Contributions are welcome, whether it is a bug fix, a new tool, or an improvement to the existing ones.

1. Fork the repository.
2. Create a feature branch:
   ```bash
   git checkout -b feature/your-tool-name
   ```
3. Commit your changes:
   ```bash
   git add .
   git commit -m "Add your tool"
   ```
4. Push the branch:
   ```bash
   git push origin feature/your-tool-name
   ```
5. Open a Pull Request.

For major changes, please open an issue first to discuss what you would like to change.

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](https://github.com/RufusTheDwarf/CouteauSuisse/blob/main/LICENSE) file for details.

---

<div align="center">

### 👤 Author

**RufusTheDwarf**

[![GitHub](https://img.shields.io/badge/GitHub-RufusTheDwarf-181717?style=flat&logo=github&logoColor=white)](https://github.com/RufusTheDwarf) [![Repository](https://img.shields.io/badge/Repo-CouteauSuisse-2ea44f?style=flat&logo=git&logoColor=white)](https://github.com/RufusTheDwarf/CouteauSuisse)

<br>

### 💖 Acknowledgements

Thanks to the open-source community for the tools and inspiration, and to Microsoft for the .NET platform and the free SDK. A special thanks to everyone who tests the toolkit and shares feedback.

<br>

### ⭐ Show Your Support

[![Star this repo](https://img.shields.io/badge/⭐_Star_this_repo-yellow?style=flat)](https://github.com/RufusTheDwarf/CouteauSuisse/stargazers) [![Report an issue](https://img.shields.io/badge/🐛_Report_an_issue-red?style=flat)](https://github.com/RufusTheDwarf/CouteauSuisse/issues) [![Fork this repo](https://img.shields.io/badge/🍴_Fork_this_repo-blue?style=flat)](https://github.com/RufusTheDwarf/CouteauSuisse/fork)

<br>

---

<sub>Made with ❤️ by **RufusTheDwarf** · MIT License · © 2026</sub>

<br>

*A pocket toolkit for everyday tasks.* 🔪

</div>
