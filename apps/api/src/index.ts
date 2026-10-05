const numbers = [1,2,3];
const first = numbers[0];
console.log(numbers.map((n) => n * 2));

interface Habit {
  id: string;
  name: string;
}

const habit: Habit = {id: '1', name: 'Read'}

if (first !== undefined){
  console.log(first.toFixed(2))
}
