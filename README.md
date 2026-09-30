<div align="center">
  <h1>CouteauSuisse</h1>
  <p>A C# console toolkit for Morse code and base conversions.</p>

  ![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
  ![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)
  ![License](https://img.shields.io/badge/license-MIT-green)
</div>

## Features

- **Morse code converter** – translate text to Morse code with audio playback.
- **Base converter** – convert between Decimal, Binary, and Octal.
- **Extensible menu** – additional utilities are planned (placeholder `(coming soon)` in the menu).

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

## Installation

```bash
git clone https://github.com/RufusTheDwarf/CouteauSuisse.git
cd CouteauSuisse
```

## Usage

From the project root, run the console application:

```bash
dotnet run --project morse.csproj
```

You will be presented with the main menu:

```
=== Couteau Suisse – Utilitaires ===
1. Convertir du texte en code Morse
2. Convertir des bases (Décimal, Binaire, Octal)
3. (à venir)
```

Choose an option and follow the on‑screen prompts.

## Project structure

```
CouteauSuisse/
├── anciennes versions/        # previous iterations of the converters
├── en-cours/                  # work‑in‑progress unified program
│   └── CouteauSuisse.cs
├── convertisseur-de-baseV4.cs # standalone base converter
├── morse.csproj               # .NET 9.0 project file
├── pseudocode.txt             # design notes
├── LICENSE                    # MIT
└── README.md
```

## License

This project is licensed under the **MIT License** – see the [LICENSE](LICENSE) file for details.
