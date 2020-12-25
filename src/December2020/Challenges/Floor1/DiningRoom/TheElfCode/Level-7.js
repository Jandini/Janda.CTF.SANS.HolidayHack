function Hello(arrays) {
    var sum = 0;
    arrays.forEach((array) => array.forEach((value) => sum += typeof (value) == "number" ? value : 0));
    return sum;
  }
  function MoveAndPull(direction, j) {
    if (direction == 1)
      elf.moveDown(direction + j);
    if (direction == 2)
      elf.moveLeft(direction + j);
    if (direction == 3)
      elf.moveUp(direction + j);
    if (direction == 4)
      elf.moveRight(direction + j);
    elf.pull_lever(direction - 1 + j);
  }
  
  for (i = 0; i < 2; i++)
    for (j = 1; j <= 4; j++)
      MoveAndPull(j, i * 4);
  elf.moveUp(2);
  elf.moveLeft(4);
  elf.tell_munch(Hello);
  elf.moveUp(1);

