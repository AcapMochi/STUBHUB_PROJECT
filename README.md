# VibeChecks
### *(solution name: `STUBHUB_PROJECT`)*

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4)
![Language](https://img.shields.io/badge/language-C%23-239120)
![UI](https://img.shields.io/badge/UI-WinForms-0078D7)
![Database](https://img.shields.io/badge/database-SQL%20Server%20LocalDB-CC2927)

A C# Windows Forms desktop app that simulates a **StubHub-style event ticket marketplace**, built and branded as **"VibeChecks."** It has two sides: a customer storefront for browsing events and buying tiered tickets, and an admin back office for managing events, venues, ticket tiers, users, and transactions — all backed by a local SQL Server database.

## Features

### Customer side
- Register / log in (`LoginForm`, `RegisterForm`)
- Browse upcoming events from a chosen date onward (`MainMenu`)
- View an event's scheduled sub-events (specific show date + venue) with poster art (`EventForm`)
- Pick ticket tiers — Basic / Premium / VIP — with a quantity stepper per tier (`EventTicketForm`)
- Checkout: order summary, billing/card entry, simulated payment confirmation (`CheckoutForm`, `CheckoutBillingForm`)
- "My Cart" — order history of paid tickets, with a printable ticket (QR code + unique reference) per order (`InventoryForm`)
- Live ticket counter shown across screens

### Admin side
- Separate admin login, restricted to accounts with `Role = 'Admin'` (`AdminLoginForm`)
- Dashboard listing every scheduled sub-event with a one-click "Cancel Event" action (`FormAdminDashboard`)
- **Manage Events** — create/edit title, category, description, poster image (`AdminAddEvent`, `AdminManageEvents`)
- **Manage Sub-Events** — schedule a date/time, venue, and status (Scheduled / Completed / Cancelled) for an event (`AdminManageSubEvent`)
- **Manage Venues** — add venues (with capacity + image) across Malaysia, the US, Canada, the UK, and Japan (`AdminManageVenues`)
- **Manage Ticket Tiers** — tier name/level, price, and total seats per sub-event (`AdminManageTickets`)
- **Manage User Accounts** — search, edit, delete user records (`AdminUserAccountsForm`)
- **Transactions** — live sales summary (tickets issued, total revenue), refund processing, printable export (`AdminTransactionsForm`)
- Admin profile editing and password change (`AdminProfileForm`, `AdminChangePassword`)

## Tech stack

| Layer | Tech |
|---|---|
| Language / runtime | C#, .NET Framework 4.7.2 |
| UI | Windows Forms (`OutputType: WinExe`) |
| Data access | ADO.NET (`System.Data.SqlClient`), raw parameterized SQL — no ORM |
| Database | SQL Server LocalDB, file-based (`VibeCheckDatabase.mdf`) |
| Printing | `System.Drawing.Printing` (GDI+) for the printable ticket layout |
| Packages | None — built entirely on base Framework reference assemblies |

## Project structure

```
STUBHUB_PROJECT/                       ← repo root
├── STUBHUB_PROJECT.slnx               ← solution file
└── STUBHUB_PROJECT/                   ← project folder
    ├── STUBHUB_PROJECT.csproj
    ├── Program.cs                     ← entry point, launches LoginForm
    ├── Ticket.cs                      ← Ticket POCO (TierID, Quantity, Price, TotalPrice)
    │
    ├── LoginForm.cs / RegisterForm.cs
    ├── MainMenu.cs
    ├── EventForm.cs / EventTicketForm.cs
    ├── CheckoutForm.cs / CheckoutBillingForm.cs
    ├── PaymentMethodForm.cs           ← stub, see Known limitations
    ├── InventoryForm.cs               ← "My Cart" / order history / ticket printing
    │
    ├── AdminLoginForm.cs / FormAdminDashboard.cs
    ├── AdminAddEvent.cs / AdminManageEvents.cs / AdminManageSubEvent.cs
    ├── AdminManageVenues.cs / AdminManageTickets.cs
    ├── AdminUserAccountsForm.cs / AdminTransactionsForm.cs
    ├── AdminProfileForm.cs / AdminChangePassword.cs
    │
    ├── Form5.cs / Form6.cs            ← unused leftover forms, no logic
    ├── Properties/                    ← AssemblyInfo, Settings
    ├── Resources/                     ← UI mock-ups + the printed-ticket QR images
    ├── VibeCheckDatabase.mdf          ← pre-built database (ships with the repo)
    └── VibeCheckDatabase_log.ldf
```

> `Resources/` also holds a few high-fidelity mock-up images (`Checkout Form.png`, `My Cart Form*.png`, `Payment Form*.png`) used as the visual target for the storefront. The actual rendered WinForms screens are simpler, functional controls rather than the gradient web-style look shown in those mock-ups.

## Database schema

All tables live in `VibeCheckDatabase`, accessed via LocalDB.

| Table | Key columns | Notes |
|---|---|---|
| `User` | `UserID`, `Username`, `Password`, `Email`, `FullName`, `Role`, `CreatedAt` | `Role` is `'User'` or `'Admin'` |
| `Events` | `EventID`, `Title`, `Category`, `Description`, `ImageData` | One event can have many sub-events |
| `SubEvents` | `SubEventID`, `EventID`, `VenueID`, `SubEventTitle`, `EventDateTime`, `ImageData`, `Status` | `Status`: Scheduled / Completed / Cancelled |
| `Venues` | `VenueID`, `VenueName`, `VenueType`, `State`, `Country`, `Capacity`, `ImageData` | |
| `TicketTiers` | `TierID`, `SubEventID`, `TierName`, `TierLevel`, `Price`, `TotalSeats`, `SeatsSold` | `TierLevel` 1/2/3 = Basic/Premium/VIP |
| `Orders` | `OrderID`, `UserID`, `OrderDate`, `TotalAmount`, `BillingName`, `OrderStatus` | `OrderStatus`: Pending / Paid |
| `OrderItems` | `OrderItemID`, `OrderID`, `TierID`, `Quantity`, `PriceAtPurchase` | |
| `Payments` | `OrderID`, `PaymentMethod`, `TransactionRef`, `PaymentStatus` | `PaymentStatus`: Paid / Refunded |

Images (event posters, venue photos, QR codes) are stored as `varbinary` blobs (`ImageData`) and rendered straight from byte arrays in-app.

## Getting started

**Prerequisites**
- Visual Studio 2022 (17.10+ recommended for native `.slnx` support) with the **.NET desktop development** workload
- SQL Server Express **LocalDB** (`MSSQLLocalDB` instance) — installed with the VS "Data storage and processing" component, or standalone

**Run it**
1. Clone the repo and open `STUBHUB_PROJECT.slnx` in Visual Studio.
2. Build the solution (`Ctrl+Shift+B`).
3. Press `F5`. The pre-built `VibeCheckDatabase.mdf`/`.ldf` already ship inside the project folder and are picked up automatically via the `|DataDirectory|` connection string — no separate restore or migration step is needed, as long as LocalDB is installed.
4. The app opens on the login screen. Use **Register** to create a customer account.

**Testing the admin side:** `RegisterForm` always inserts new accounts with `Role = 'User'` — there's no in-app sign-up flow for admins. To explore the admin dashboard, open `VibeCheckDatabase.mdf` in SQL Server Object Explorer and manually set an existing user's `Role` column to `'Admin'`, then use the **Admin** link on the login screen.

## Application flow

```
Customer:
LoginForm ──▶ RegisterForm
   │
   ▼
MainMenu ──▶ EventForm ──▶ EventTicketForm ──▶ CheckoutForm ──▶ CheckoutBillingForm
   │                                                │
   └──────────────▶ InventoryForm ("My Cart") ◀─────┘
                          │
                          ▼
                   PaymentMethodForm  (stub)

Admin:
LoginForm ──▶ AdminLoginForm ──▶ FormAdminDashboard
                                    ├──▶ AdminManageEvents ──▶ AdminAddEvent / AdminManageSubEvent
                                    ├──▶ AdminManageVenues
                                    ├──▶ AdminManageTickets
                                    ├──▶ AdminUserAccountsForm
                                    ├──▶ AdminTransactionsForm
                                    └──▶ AdminProfileForm ──▶ AdminChangePassword
```

## Known limitations

- **Plain-text passwords** — `User.Password` is stored and compared as-is, with no hashing/salting. Fine for a class project; would need fixing before any real deployment.
- **No in-app admin sign-up** — registration always sets `Role = 'User'`; admin accounts must be created by editing the database directly.
- **Duplicated connection string** — the LocalDB connection string is hardcoded in nearly every form's code-behind instead of being centralized in `App.config`, so changing the DB path means editing ~15 files.
- **Unfinished screens** — `PaymentMethodForm` (reached from My Cart → Checkout) and the leftover `Form5` / `Form6` files contain no real logic; they look like scaffolding from an earlier pass that was superseded by the `CheckoutForm` flow.
- **No data-access layer** — SQL is parameterized (so it's safe from injection) but lives directly in form code-behind rather than a separate repository/service layer.
- **No automated tests.**

## License

No license file is currently included in this repository.
