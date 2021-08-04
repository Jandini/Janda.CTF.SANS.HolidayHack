function hello(objects) {
    console.log(objects);
    objects.forEach((o) => {
        for (key in o) {
            console.log(`${key}: ${o[key]}`);
            if (o[key] == "lollipop")
                result = key;
        }
    });

    console.log(result);
    return result;
}

let sum = 0
for (i = 0; i < 6; i++) {
    if ((i % 2) == 0)
        elf.moveRight(i * 2 + 1);
    else
        elf.moveLeft(i * 2 + 1);

    elf.pull_lever((sum += elf.get_lever(i)))
    elf.moveUp(3);
}
elf.ask_munch(0);
elf.tell_munch(hello);
elf.moveRight(11);
