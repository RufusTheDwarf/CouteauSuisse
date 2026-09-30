<div align="center">
  <h1>CouteauSuisse</h1>

  <p>A pocket console toolkit for Windows: turn text into Morse code you can hear, and convert numbers between binary, decimal and octal.</p>

  ![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
  ![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat&logo=dotnet&logoColor=white)
  ![Platform](https://img.shields.io/badge/platform-Windows-0078D4?style=flat&logo=windows&logoColor=white)
  ![Release](https://img.shields.io/github/v/release/RufusTheDwarf/CouteauSuisse?style=flat)
  ![License](https://img.shields.io/github/license/RufusTheDwarf/CouteauSuisse?style=flat)

  **[⬇ Download the latest release](https://github.com/RufusTheDwarf/CouteauSuisse/releases/latest)**

  **Quick Links:** [Features](#-features) · [Download](#-download) · [Usage](#-usage) · [Build from Source](#-build-from-source) · [Project Structure](#-project-structure) · [Contributing](#-contributing) · [License](#-license)
</div>

---

## Overview

CouteauSuisse is a single self-contained `.exe` — no installation, no runtime to download. Launch it, pick a tool from the menu, get your result, and go again or quit.

The interface is in French.

---

## ✨ Features

### 📡 Text → Morse

| Feature | Detail |
|---|---|
| **Supported characters** | Letters `A–Z` (no accents), digits `0–9`, punctuation `. , : ; ? ! - _ / ( ) & = + " ' $ @` |
| **Separators** | Words are separated with `/`, letters with a space |
| **Audio playback** | System speaker, 800 Hz tone — dot = 200 ms, dash = 600 ms |
| **Error handling** | Unsupported characters are rejected and you are asked to retype |

### 🔢 Base Converter

| # | Conversion |
|---|---|
| 1 | Decimal → Binary |
| 2 | Binary → Decimal |
| 3 | Binary → Octal |
| 4 | Octal → Binary |

Works on 32-bit integers. Invalid input returns an error message instead of closing the program.

### 🧭 Menu

- Input validation on every prompt
- Restart or quit after each conversion
- Option 3 is reserved for a future tool

---

## Download

1. Grab `morse.exe` from the [latest release](https://github.com/RufusTheDwarf/CouteauSuisse/releases/latest).
2. Double-click it, or run it from a terminal.

> [!IMPORTANT]
> **Windows only** — the audio uses `Console.Beep` with a custom frequency, which is not supported on Linux/macOS.

---

## 🚀 Usage

### Main Menu

```text
 ╔═════════════════════════════════════╗
 ║                                     ║
 ║           Couteau suisse            ║
 ║                                     ║
 ╚═════════════════════════════════════╝
 === Couteau Suisse – Utilitaires ===
 1. Convertir du texte en code Morse
 2. Convertir des bases (Décimal, Binaire, Octal)
 3. (à venir)
 Veuillez choisir une option :
```

### Morse Conversion

```text
 Entrez un mot ou une phrase (chiffres 0-9 et lettres sans accents) : SOS
 Résultat en Morse : ... --- ...
```

### Base Conversion

```text
 === Convertisseur de bases ===
 1. Décimal > Binaire
 ...
 Veuillez entrer un nombre : 42
 Résultat : 101010
```

---

## 🛠 Build from Source

> [!NOTE]
> Requires the [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0).

```bash
git clone https://github.com/RufusTheDwarf/CouteauSuisse.git
cd CouteauSuisse
dotnet run
```

**Single-file executable:**

```bash
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

---

## 📁 Project Structure

```text
CouteauSuisse/
├── en-cours/                    # current program (menu, Morse, base converter)
│   └── CouteauSuisse.cs
├── anciennes versions/          # earlier iterations, excluded from the build
├── convertisseur-de-baseV4.cs   # standalone base converter, excluded from the build
├── morse.csproj
└── LICENSE
```

---

## 🤝 Contributing

Contributions are welcome! If you have an idea for a new tool, a bug fix, or an improvement:

1. Fork the repository
2. Create a feature branch (`feature/your-tool-name`)
3. Commit your changes
4. Open a Pull Request

For major changes, please open an issue first to discuss what you'd like to change.

---

<div align="center">

## 📄 License

MIT — see [LICENSE](LICENSE).

<br>

Made with ❤️ by [RufusTheDwarf](https://github.com/RufusTheDwarf)

⭐ If you find this project useful, consider giving it a star!

</div>
