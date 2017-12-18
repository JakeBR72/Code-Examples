import components.statement.Statement;
import components.statement.StatementKernel.Condition;

/**
 * Utility class with method to count the number of calls to primitive
 * instructions (move, turnleft, turnright, infect, skip) in a given
 * {@code Statement}.
 *
 * @author Put your name here
 *
 */
public final class CountPrimitiveCalls {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private CountPrimitiveCalls() {
    }

    /**
     * Reports the number of calls to primitive instructions (move, turnleft,
     * turnright, infect, skip) in a given {@code Statement}.
     *
     * @param s
     *            the {@code Statement}
     * @return the number of calls to primitive instructions in {@code s}
     * @ensures
     *
     *          <pre>
     * countOfPrimitiveCalls =
     *  [number of calls to primitive instructions in s]
     *          </pre>
     */
    public static int countOfPrimitiveCalls(Statement s) {
        int count = 0;
        switch (s.kind()) {
            case BLOCK: {
                for (int i = 0; i < s.lengthOfBlock(); i++) {
                    Statement child = s.newInstance();
                    child = s.removeFromBlock(i);
                    count += countOfPrimitiveCalls(child);
                    s.addToBlock(i, child);
                }
                break;
            }
            case IF: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleIf(block);
                count += countOfPrimitiveCalls(block);
                s.assembleIf(condition, block);
                break;
            }
            case IF_ELSE: {
                Statement blockLeft = s.newInstance();
                Statement blockRight = s.newInstance();
                Condition condition = s.disassembleIfElse(blockLeft,
                        blockRight);
                count += (countOfPrimitiveCalls(blockLeft)
                        + countOfPrimitiveCalls(blockRight));
                s.assembleIfElse(condition, blockLeft, blockRight);
                break;
            }
            case WHILE: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleWhile(block);
                count += countOfPrimitiveCalls(block);
                s.assembleWhile(condition, block);
                break;
            }
            case CALL: {
                String call = s.disassembleCall();
                switch (call) {
                    case "move":
                    case "turnleft":
                    case "turnright":
                    case "infect":
                    case "skip": {
                        count = 1;
                        break;
                    }
                    default: {
                        break;
                    }

                }
                s.assembleCall(call);
                break;
            }
            default: {
                break;
            }
        }
        return count;
    }

    public static int countOfInstructionCalls(Statement s, String instr) {
        int count = 0;
        switch (s.kind()) {
            case BLOCK: {
                for (int i = 0; i < s.lengthOfBlock(); i++) {
                    Statement child = s.newInstance();
                    child = s.removeFromBlock(i);
                    count += countOfInstructionCalls(child, instr);
                    s.addToBlock(i, child);
                }
                break;
            }
            case IF: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleIf(block);
                count += countOfInstructionCalls(block, instr);
                s.assembleIf(condition, block);
                break;
            }
            case IF_ELSE: {
                Statement blockLeft = s.newInstance();
                Statement blockRight = s.newInstance();
                Condition condition = s.disassembleIfElse(blockLeft,
                        blockRight);
                count += (countOfInstructionCalls(blockLeft, instr)
                        + countOfInstructionCalls(blockRight, instr));
                s.assembleIfElse(condition, blockLeft, blockRight);
                break;
            }
            case WHILE: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleWhile(block);
                count += countOfInstructionCalls(block, instr);
                s.assembleWhile(condition, block);
                break;
            }
            case CALL: {
                String call = s.disassembleCall();
                switch (call) {
                    case "move": {
                        break;
                    }
                    case "turnleft": {
                        break;
                    }
                    case "turnright": {
                        break;
                    }
                    case "infect": {
                        break;
                    }
                    case "skip": {
                        break;
                    }
                    default: {
                        count = 1;
                        break;
                    }
                }
                s.assembleCall(call);
                break;
            }
            default: {
                break;
            }
        }
        return count;
    }

    public static void renameInstruction(Statement s, String oldName,
            String newName) {
        switch (s.kind()) {
            case BLOCK: {
                for (int i = 0; i < s.lengthOfBlock(); i++) {
                    Statement child = s.newInstance();
                    child = s.removeFromBlock(i);
                    renameInstruction(child, oldName, newName);
                    s.addToBlock(i, child);
                }
                break;
            }
            case IF: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleIf(block);
                renameInstruction(block, oldName, newName);
                s.assembleIf(condition, block);
                break;
            }
            case IF_ELSE: {
                Statement blockLeft = s.newInstance();
                Statement blockRight = s.newInstance();
                Condition condition = s.disassembleIfElse(blockLeft,
                        blockRight);
                renameInstruction(blockLeft, oldName, newName);
                renameInstruction(blockRight, oldName, newName);
                s.assembleIfElse(condition, blockLeft, blockRight);
                break;
            }
            case WHILE: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleWhile(block);
                renameInstruction(block, oldName, newName);
                s.assembleWhile(condition, block);
                break;
            }
            case CALL: {
                String call = s.disassembleCall();
                if (call.equals(oldName)) {
                    call = newName;
                }
                s.assembleCall(call);
                break;
            }
            default: {
                break;
            }
        }
    }

    public static void simplifyIfElse(Statement s) {
        switch (s.kind()) {
            case BLOCK: {
                for (int i = 0; i < s.lengthOfBlock(); i++) {
                    Statement child = s.newInstance();
                    child = s.removeFromBlock(i);
                    simplifyIfElse(child);
                    s.addToBlock(i, child);
                }
                break;
            }
            case IF: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleIf(block);
                simplifyIfElse(block);
                s.assembleIf(condition, block);
                break;
            }
            case IF_ELSE: {
                Statement blockLeft = s.newInstance();
                Statement blockRight = s.newInstance();
                Condition condition = s.disassembleIfElse(blockLeft,
                        blockRight);
                Condition newCondition = condition;
                switch (condition) {
                    case NEXT_IS_NOT_ENEMY: {
                        newCondition = condition.NEXT_IS_ENEMY;
                        break;
                    }
                    case NEXT_IS_NOT_EMPTY: {
                        newCondition = condition.NEXT_IS_EMPTY;
                        break;
                    }
                    case NEXT_IS_NOT_FRIEND: {
                        newCondition = condition.NEXT_IS_FRIEND;
                        break;
                    }
                    case NEXT_IS_NOT_WALL: {
                        newCondition = condition.NEXT_IS_WALL;
                        break;
                    }
                    default: {
                        break;
                    }
                }
                simplifyIfElse(blockLeft);
                simplifyIfElse(blockRight);
                s.assembleIfElse(newCondition, blockRight, blockLeft);
                break;
            }
            case WHILE: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleWhile(block);
                simplifyIfElse(block);
                s.assembleWhile(condition, block);
                break;
            }
            case CALL: {
                // nothing to do here...can you explain why?
                break;
            }
            default: {
                // this will never happen...can you explain why?
                break;
            }
        }
    }
}
