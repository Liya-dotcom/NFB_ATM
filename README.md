# NFB ATM Simulator - C# Console Application  

## Overview  
This is a simple **ATM (Automated Teller Machine) simulator** built using **C#** and the **.NET framework**. It demonstrates secure banking operations with performance monitoring capabilities.

## Key Features  

### 🔒 Security Features  
- **PIN encryption** using SHA-256 hashing  
- Hidden PIN input with asterisks (`*`)  
- Input validation for 4-5 digit PINs  

### 💰 Banking Operations  
- Deposit money into account  
- Check account balance  
- Withdraw money (in multiples of 50)  
- Transaction confirmation prompts  

### ⚡ Performance Monitoring  
- High-precision timing using `Stopwatch`  
- Multiple time measurement formats:  
  - Milliseconds precision  
  - Human-readable formatted time  
  - Start/stop/reset functionality  

## Code Structure  

```
NFB_ATM/
├── Program.cs            - Main application logic
├── Timing.cs             - Performance measurement class
└── (Future expansions)   - Potential for transaction history, etc.
```

## Getting Started  

### Requirements  
- .NET 6.0 or later  
- Visual Studio 2022 (or any C# IDE)  

### Installation  
1. Clone the repository  
2. Open solution in Visual Studio  
3. Build and run the project  

## Usage Example  

```csharp
// Initialize performance timer
Timing perfTimer = new Timing();

// Start transaction timing
perfTimer.StartTime();

// Perform ATM operations
ATMService.ProcessTransaction();

// Stop timing and display results
perfTimer.StopTime();
Console.WriteLine($"Transaction completed in {perfTimer.ElapsedMilliseconds()} ms");
```

## Enhanced Timing Class Features  

| Method | Description | Return Type |
|--------|-------------|-------------|
| `StartTime()` | Begins performance measurement | void |
| `StopTime()` | Stops measurement | void |
| `Reset()` | Resets timer to zero | void |
| `Result()` | Gets raw elapsed time | TimeSpan |
| `ElapsedMilliseconds()` | Gets precise milliseconds | double |
| `ElapsedSeconds()` | Gets precise seconds | double |
| `GetFormattedTime()` | Gets HH:MM:SS.mmm format | string |

## Future Improvements  
- [ ] Add transaction history logging  
- [ ] Implement multiple user accounts  
- [ ] Create graphical interface  
- [ ] Add unit tests  

## Contributor  
    Liyabona Thebe

---
**Note**: This project is part of my developer portfolio. 

🚀 **Happy coding!**  

MIT License - Open source and free to modify/use  

