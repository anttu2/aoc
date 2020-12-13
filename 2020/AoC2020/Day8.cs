using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class Day8
    {
        private readonly IList<Instruction> _instructions;

        public Day8(string program)
        {
            _instructions = Parse(program);
        }

        private IList<Instruction> Parse(string program)
        {
            var instructionLines = program.SplitByNewLine();

            return instructionLines
                .Select(InstructionFactory.CreateInstance)
                .ToList();
        }

        public int GetAccumulatorOnFirstLoop()
        {
            var executor = new Executor(_instructions);
            executor.Run();

            return executor.Accumulator;
        }

        public int HealBootSeqAndGetAccumulatorOnSuccesfulExecution()
        {
            var jumpAndNopInstructions = _instructions.Where(i => i is Jmp || i is Nop).ToList();

            foreach (var jumpOrNop in jumpAndNopInstructions)
            {
                var instructionSet = _instructions.ToList();
                instructionSet.ForEach(i => i.Executed = false);

                var index = instructionSet.IndexOf(jumpOrNop);
                var acc = new Nop();
                instructionSet[index] = acc;

                var executor = new Executor(instructionSet);
                var exited = executor.Run();

                if (exited)
                {
                    return executor.Accumulator;
                }
            }

            throw new Exception("Couldn't heal boot sequence");
        }

        public class Executor
        {
            private readonly IList<Instruction> _instructions;

            public int Accumulator { get; set; }
            public int Pointer { get; set; }

            public Executor(IList<Instruction> instructions)
            {
                _instructions = instructions;
            }

            public bool Run()
            {
                while(true)
                {
                    if (Pointer >= _instructions.Count)
                    {
                        // wre've reached the end of the boot sequence
                        return true;
                    }

                    var instr = _instructions[Pointer];

                    if (instr.Executed)
                    {
                        // found loop, halt execution
                        return false;
                    }

                    var acc = Accumulator;
                    var p = Pointer;
                    
                    instr.Execute(ref acc, ref p);
                    
                    Accumulator = acc;
                    Pointer = p;
                }
            }
        }

        public static class InstructionFactory
        {
            public static Instruction CreateInstance(string instruction)
            {
                Instruction instance;

                var parts = instruction.Split(' ');
                var op = parts[0];
                var val = int.Parse(parts[1]);

                switch (op)
                {
                    case "nop":
                        instance = new Nop();
                        break;
                    case "acc":
                        instance = new Acc(val);
                        break;
                    case "jmp":
                        instance = new Jmp(val);
                        break;
                    default:
                        throw new ArgumentException($"Unknown operation {op}");
                }

                return instance;
            }
        }

        public class Nop : Instruction
        {
            public Nop() : base(default) { }
        }

        public class Acc : Instruction
        {
            public Acc(int val) : base(val) { }

            public override void Execute(ref int accumulator, ref int pointer)
            {
                accumulator += Val;

                base.Execute(ref accumulator, ref pointer);
            }
        }

        public class Jmp : Instruction
        {
            public Jmp(int val) : base(val) { }

            public override void Execute(ref int accumulator, ref int pointer)
            {
                pointer += Val;
                Executed = true;
            }
        }

        public abstract class Instruction
        {
            public Instruction(int val)
            {
                Val = val;
            }

            public int Val { get; }
            public bool Executed { get; set; }

            public virtual void Execute(ref int accumulator, ref int pointer)
            {
                pointer++;
                Executed = true;                
            }
        }
    }


}
