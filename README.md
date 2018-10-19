# todo-app
> Simple console-based to-do app created in C#

All todo tasks are stored locally in a file between runs.

## Usage
```
    Usage
    $ btc-value
    Options
        Add [item]      Add a item to the todo application
        Do #[number]    Complete a given item
        Print           Print all todo items
        Help            Show all possible options
        Exit            Exit the command line application

    Examples
    > Add Apply to DIPS
        $16258
    >Add Apply to DIPS
    12 Apply to DIPS
    >Add Complete assignment
    #2 Complete assignment
    >Print
    #1 Apply to DIPS
    #2 Complete assignment
    >Do #1
    Completed #1 Apply to DIPS
    >Do #2
    Completed #2 Complete assignment
```

## Options
### `Add`
Add a item to the todo application.

### `Do`
Complete a given item. Specified by a number.

### `Print`
Print all todo items that are saved.

### `Help`
Show all possible options.

### `Exit`
Exit the command line application. All items are stored in a file till next time.

## Tests
Tests can be run using the tools inside Visual Studio for running and are made using MSTest.
