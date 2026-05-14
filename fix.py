content = open('Assets/Scenes/SampleScene.unity', 'r', encoding='utf-8').read()
lines = content.split('\n')
result = []
skip_ours = False
keep_theirs = False

for line in lines:
    if line.startswith('<<<<<<<'):
        skip_ours = True
        keep_theirs = False
    elif line.startswith('=======') and skip_ours:
        skip_ours = False
        keep_theirs = True
    elif line.startswith('>>>>>>>') and keep_theirs:
        keep_theirs = False
    elif not skip_ours:
        result.append(line)

open('Assets/Scenes/SampleScene.unity', 'w', encoding='utf-8').write('\n'.join(result))
print('Done! Conflicts fixed.')