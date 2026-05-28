**GIT Auto-Push (Otomatik Push) – Kılavuz**

Bu belge, yerel geliştirme sırasında her commit sonrası otomatik `git push` yapılmasını sağlayacak basit bir kurulum sunar. Otomatik push yerel akışları hızlandırır ama dikkatli kullanılmalıdır — özellikle doğrudan `main`/`master` veya korunan dallara push atmayın.

Özet
- **Yöntem:** Yerel Git hook (`post-commit`) çalıştırılarak otomatik push
- **Platform:** Windows (PowerShell) — Git for Windows ile uyumlu
- **Kurulum:** `scripts\install_git_hooks.ps1` çalıştırarak `.githooks` içeriği `.git/hooks` içine kopyalanır

Gerekçeler ve Güvenlik
- Otomatik push, küçük yerel değişiklikleri hızlıca uzak sunucuya göndermek için kullanışlıdır.
- Uyarı: Otomatik push, hatalı veya eksik commitleri paylaşabilir. Önerilen kullanım: feature dallarında ve korumalı dallara otomatik push kapalıyken.

Dosya açıklamaları
- `.githooks/post-commit`: Örnek hook — commit sonrası `git push` çalıştırır
- `scripts/install_git_hooks.ps1`: Hook’ları `.git/hooks` içine kopyalamak için yardımcı script

Kurulum
1. İzinleri ayarlayın (PowerShell'i yönetici olmanıza gerek yok):

```powershell
Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned -Force
```

2. Repodaki kök dizininden kurulum script'ini çalıştırın:

```powershell
.\scripts\install_git_hooks.ps1
```

3. Deneme: Yeni bir değişiklik yapın, commit atın; hook otomatik olarak `git push` çalıştıracaktır.

Nasıl devre dışı bırakılır
- `.git/hooks/post-commit` dosyasını silin veya içeriğini yorum satırı yapın.

Örnek davranış
- Commit başarılıysa uzak sunucuya `git push` denenecek.
- Push başarısız olursa hata mesajı göreceksiniz; hook hata kodunu döndürür.

İpuçları
- Eğer uzak `main` branch'ına otomatik push istemiyorsanız, hook içine dal kontrolü ekleyin.
- Çakışma, rebase veya protected branch kuralları durumlarında otomatik push beklenmeyen hatalar verebilir — manuel müdahale gerekebilir.

Sorularınız varsa hangi dalda otomatik push istediğinizi söyleyin; örnek hook'ı buna göre güncellerim.
