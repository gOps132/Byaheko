# Biyaheko Travel & Tours — Final Spec

## 1. Concept
- **Type:** Local travel agency site (Philippines focus).
- **Brand:** Biyaheko Travel & Tours. Tagline: "Discover the Philippines in style."
- **Goal:** Exam model that looks and feels real: browse packages → story-first detail → validated booking inquiry with fanfare confirmation → My Bookings list.
- **Audience:** Professor grading (navigation, forms, validation, design, motion) + plausible guest realism.
- **Motion lens:** `travel-hospitality` skill (Disney 12 principles applied to travel). Motion transports users mentally before they travel physically. CSS-keyframes only, no JS animation library. Impeccable explicitly deferred.

## 2. Routes & pages
| Route | Page | Contents |
|---|---|---|
| `/` | Home (spectacular landing) | Ink-drenched full-bleed El Nido lagoon hero with Ken Burns drift + staggered headline reveal + gold CTA; marquee destination strip; featured packages (staggered cards); why-BiyaheKo band; testimonial; big CTA footer |
| `/packages` | Packages | Imagery-first card grid (4); search box + sort select; staggered entrance on load and on filter change |
| `/packages/{slug}` | Package detail | Story-first: 3-photo crossfade gallery + dots; itinerary timeline; inclusions/exclusions; sticky booking rail with live total; unknown slug → not-found + back link |
| `/my-trips` | My Bookings | In-memory list; total-spent header; Confirmed badges; cancel buttons; empty state |
| `/about` | About & Contact | Agency story, contact info, inquiry form with success message |

Out of scope: auth, DB, payments, admin, cart checkout, email sending, maps.

## 3. Data (in-memory)
- `Models/TourPackage.cs`: Slug, Title, Destination, Category (Island/Beach/Culture/Adventure), DurationDays, PricePerPerson, Rating, ImageUrl + GalleryUrls (3), Summary, Highlights, Inclusions, Exclusions, Itinerary (Day → text).
- `Models/Booking.cs`: Id, PackageSlug, FullName, Email, TravelDate (≥ today), Guests (1–20), Notes, CreatedAt. DataAnnotations validation.
- `Services/TourData.cs`: static seed, 4 packages:
  1. El Nido Island Escape (Palawan, Island, 4D3N, ₱18,500)
  2. Boracay Luxury Retreat (Beach, 3D2N, ₱15,000)
  3. Cebu Heritage & Falls (Culture, 3D2N, ₱12,800)
  4. Bohol Nature Adventure (Adventure, 3D2N, ₱11,500)
- `Services/BookingState.cs`: scoped, `List<Booking>` + TotalSpent. Volatile (dies on refresh); stated demo assumption, no localStorage.

## 4. Booking flow (pose-to-pose, current step focused)
1. Detail page sticky rail: EditForm + DataAnnotationsValidator; live total = price × guests, pulses/sparkles on change.
2. Invalid submit: messages fade/slide in per field (300ms ease-out), border transitions gold→red. No shake.
3. Valid submit → two-beat confirmation: 400ms suspense pause with location-themed loader → success panel (animated gold check-draw, total, reference code, "View My Trips" CTA) + 600ms custom-bounce fanfare with subtle confetti/sparkle.
4. Booking added to BookingState; My Bookings shows Confirmed badge; cancel removes.

## 5. Motion system (from travel-hospitality skill)
| Action | Duration | Easing | Notes |
|---|---|---|---|
| Search feedback / button press | 150ms | ease-out | CTA squash on press + hover lift (transform only) |
| Search results cascade | 250ms | ease-out | 60ms per-card stagger, re-trigger on filter change |
| Booking step transition | 300ms | ease-in-out | form ↔ loader ↔ success |
| Gallery crossfade | 400ms | ease-in-out | dots, arrows, no autoplay |
| Aspirational reveals | 400–500ms | ease-out | scroll-reveal via 30-line IntersectionObserver |
| Confirmation fanfare | 600ms | custom-bounce | check-draw + confetti/sparkle |
- Hero: 8s Ken Burns drift on single lagoon photo; headline lines stagger in on load.
- Baseline: content readable with zero motion; one `@media (prefers-reduced-motion: reduce)` block kills all keyframes/transitions.
- Never animate layout properties (transform/opacity only).

## 6. Design (luxury, imagery-first staging)
- Palette: deep ink `#14120E`-ish drenched hero + footer, ivory `#FAF7F2` body, gold `#C9A227` Committed (section bands, badges, CTAs, dividers), muted gray text. Tinted neutrals, never pure black/white.
- Type: Marcellus (display) + Jost (body) via Google Fonts. Oversized left-aligned hero wordmark, not centered-stack template.
- PackageCard: full-bleed photo dominant, title + one-line dream copy, price/duration quiet secondary row. `repeat(auto-fit, minmax(280px, 1fr))` grid.
- Detail: left story (gallery, timeline, inclusions), right sticky booking rail.
- Header: NavLink active gold underline + mobile hamburger toggle. Footer: ink-drenched, big CTA.

## 7. Imagery
- Hotlinked Unsplash (`images.unsplash.com/photo-{id}?auto=format&fit=crop&w=1600&q=80`), 1 hero + 3 gallery photos per package + testimonial avatar. Confident IDs only; gradient fallback behind every image.
- Alt text in brand voice ("Big Lagoon karsts at first light, El Nido"), not "beach photo".

## 8. Tech & structure
- Blazor Server (existing `net10.0` template, InteractiveServer render mode) + Tailwind via CDN script tag in head. No MudBlazor/Radzen.
```
Components/Shared/ (SiteHeader, SiteFooter, PackageCard, RatingStars, EmptyState, Reveal wrapper)
Components/Booking/ (BookingForm, BookingSuccess)
Pages/ (Home, Packages, PackageDetail, MyTrips, About)
Models/ (TourPackage, Booking)
Services/ (TourData, BookingState)
wwwroot/css/site.css (fonts, tokens, keyframes, stagger, kill-switch)
wwwroot/js/reveal.js (IntersectionObserver, ~30 lines)
```
- State: scoped BookingState + local component state.

## 9. Build & verify
- `dotnet restore && dotnet build`; fix errors before polish.
- Checklist: home hero drifts + reveals; filter/sort staggers; detail gallery crossfades; invalid booking fades messages; valid booking pauses → fanfare → appears in My Trips with total; cancel works; reduced-motion kills animation.

## 10. Implementation order
1. Models + TourData seed + BookingState DI + routes.
2. site.css tokens + keyframes + kill-switch; header/footer; reveal.js.
3. Home landing (hero, strip, featured, why-us, testimonial, CTA).
4. Packages + search/sort stagger.
5. Detail + gallery + sticky rail + two-beat confirmation.
6. My Trips + About; verify checklist.
