# BioMusic

BioMusic is a historical C# / Windows Forms prototype exploring procedural
MIDI music. Its code models musical structures such as songs, phrases,
measures, and notes, and includes random generation and MIDI playback
experiments. Genetic-algorithm classes are present, but an end-to-end system
that evolves music was not established in the reviewed snapshot.

## Status

Archived experiment and code sample. This staged version has not been built
or run. The project targets .NET Framework 3.5 and references external Sanford
MIDI, midi-dot-net and ObjectListView projects or libraries that are not
included here; their compatible versions, licenses and installation paths
need to be verified. Some original resources and dependencies are absent, so
this is not a ready-to-run checkout.

## Staging changes

- Application C# source is preserved from the supplied archive.
- Build outputs, compiled libraries, executables, sample MIDI, screenshots,
  separate images, nested archives and the signing certificate are omitted.
- Embedded images were removed from WinForms `.resx` files pending provenance
  review; related UI resources may therefore be missing at runtime.
- `BioMusic.csproj` was sanitized: its old deployment URLs, certificate
  references and certificate file entry were removed, and manifest signing
  was disabled. Its external project references remain as historical clues.

Original third-party components are not claimed as authored by this project.
No open-source license has been selected for this staging copy.
