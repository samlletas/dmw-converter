# DMW Converter
Command line tool to convert DefleMask's binary wavetable files (.dmw) to human readable text files.

## Synopsis

    .\dmw-converter.exe [directory] [extension]

## Description

You must provide a path to a directory that contains the `.dmw` files you wish to convert and the file extension to use for the generated text files, for example:

    .\dmw-converter.exe C:\Users\Foo\Desktop\DefleMask\wavetables txt

After running the tool a new subdirectory named `Export` containing all the generated text files will be created.

# Development Environment

Install the .NET 7.0 SDK and build the project with:

    dotnet build

## Making Commits

All commits should be made using the [conventional commits](https://www.conventionalcommits.org/en/v1.0.0/#summary) specification, to help with this a git hook that validates commit messages can be installed with:

     cp -r -T .githooks .git/hooks

## Reference Material
- https://github.com/Pegmode/dmwStringConvertTools
- https://github.com/zeromus/chipifier
